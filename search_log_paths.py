import os
import glob

# Resolve the current user profile path dynamically
user_profile = os.environ.get("USERPROFILE", r"C:\Users\lenovo")
brain_dir = os.path.join(user_profile, ".gemini", "antigravity", "brain")

default_conv_id = "de4ec850-534d-409b-9b76-a107addfbf47"
log_path = os.path.join(brain_dir, default_conv_id, ".system_generated", "logs", "overview.txt")

if not os.path.exists(log_path):
    print(f"[INFO] Path log default untuk {default_conv_id} tidak ditemukan.")
    # Fallback to the latest brain session's overview.txt
    if os.path.exists(brain_dir):
        overview_files = glob.glob(os.path.join(brain_dir, "*", ".system_generated", "logs", "overview.txt"))
        if overview_files:
            # Sort by modification time of the overview.txt
            overview_files.sort(key=os.path.getmtime, reverse=True)
            log_path = overview_files[0]
            conv_id = os.path.basename(os.path.dirname(os.path.dirname(os.path.dirname(log_path))))
            print(f"[INFO] Menggunakan log percakapan terbaru: {conv_id}")
        else:
            print(f"ERROR: Tidak ditemukan file overview.txt di {brain_dir}")
            exit(1)
    else:
        print(f"ERROR: Direktori brain {brain_dir} tidak ditemukan.")
        exit(1)

with open(log_path, 'r', encoding='utf-8', errors='ignore') as f:
    lines = f.readlines()

for idx, line in enumerate(lines):
    if "kuliah wati" in line or "projek kp" in line or "pertamina" in line:
        print(f"Line {idx}: {line[:200]}...")
