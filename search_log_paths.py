log_path = r"C:\Users\asus\.gemini\antigravity\brain\de4ec850-534d-409b-9b76-a107addfbf47\.system_generated\logs\overview.txt"

with open(log_path, 'r', encoding='utf-8') as f:
    lines = f.readlines()

for idx, line in enumerate(lines):
    if "kuliah wati" in line or "projek kp" in line:
        print(f"Line {idx}: {line[:200]}...")
