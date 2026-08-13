with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

idx = 0
found = []
while True:
    i = text.find('<!-- Laporan Progres Teknisi (di bawah tabel penugasan) -->', idx)
    if i == -1: break
    found.append(i)
    idx = i + 10

print("Indices:", found)
