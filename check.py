with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

count = 1
idx = 0
while True:
    idx = text.find('Laporan Progres Teknisi', idx)
    if idx == -1: break
    print(f"Match {count}:")
    sub = text[idx:idx+1500]
    foreach_idx = sub.find('foreach')
    if foreach_idx != -1:
        print(sub[foreach_idx:foreach_idx+60].strip())
    else:
        print("No foreach found within 1500 chars")
    
    idx += 1
    count += 1
