with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

import re
text = re.sub(r'@onclick\s*=\s*"[^"]*\(\)\s*=>\s*\{?\s*\}?[^"]*"', '', text)

# Just to be safe for any weird lambda
text = text.replace('@onclick="() => {}"', '')
text = text.replace('@onclick="() => () => {}"', '')
text = text.replace('@onclick=") => {}"', '')

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)
