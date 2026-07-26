import os
import glob

# Resolve the current user profile path dynamically
user_profile = os.environ.get("USERPROFILE", r"C:\Users\lenovo")
pb_dir = os.path.join(user_profile, ".gemini", "antigravity", "conversations")

default_filename = "de4ec850-534d-409b-9b76-a107addfbf47.pb"
pb_path = os.path.join(pb_dir, default_filename)

if not os.path.exists(pb_path):
    print(f"[INFO] File default ({default_filename}) tidak ditemukan di {pb_dir}.")
    # Fallback to the latest .pb file in the directory
    if os.path.exists(pb_dir):
        pb_files = glob.glob(os.path.join(pb_dir, "*.pb"))
        if pb_files:
            pb_files.sort(key=os.path.getmtime, reverse=True)
            pb_path = pb_files[0]
            print(f"[INFO] Menggunakan file percakapan terbaru: {os.path.basename(pb_path)}")
        else:
            print(f"ERROR: Tidak ditemukan file .pb di direktori {pb_dir}")
            exit(1)
    else:
        print(f"ERROR: Direktori {pb_dir} tidak ditemukan.")
        exit(1)

with open(pb_path, 'rb') as f:
    data = f.read()

print(f"File size: {len(data)}")

# Search for pertamina case-insensitive in raw bytes
matches = []
for i in range(len(data) - 9):
    slice_bytes = data[i:i+9].lower()
    if slice_bytes == b'pertamina':
        matches.append(i)

print(f"Found {len(matches)} matches for 'pertamina' in raw bytes.")
if matches:
    print("Match offsets:", matches)
    # Print the surrounding bytes for the first match
    offset = matches[0]
    start = max(0, offset - 100)
    end = min(len(data), offset + 500)
    print("Snippet:")
    print(data[start:end].decode('utf-8', errors='replace'))
