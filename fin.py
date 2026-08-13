with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

text = text.replace('status == "Menunggu Konfirmasi"', 'statusLabel == "Menunggu Konfirmasi"')
text = text.replace('Task.CompletedTask', '() => {}')

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)
