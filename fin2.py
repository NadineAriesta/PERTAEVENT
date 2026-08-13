with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    text = f.read()

import re
text = re.sub(r'@onclick="\(\) => \{\}"', '', text)

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.write(text)
