with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    lines = f.readlines()
    for i in range(1045, 1060):
        print(f'{i+1}: {lines[i].strip()}')
