import re

pb_path = r"C:\Users\asus\.gemini\antigravity\conversations\de4ec850-534d-409b-9b76-a107addfbf47.pb"

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
