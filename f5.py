with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

if '@using System.Threading.Tasks' not in text:
    text = '@using System.Threading.Tasks\n' + text
    with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
        f.write(text)
