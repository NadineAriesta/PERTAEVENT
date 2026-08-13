with open('Components/Pages/Home.razor', 'r', encoding='utf-8') as f:
    lines = f.readlines()

new_lines = []
skip = False
for i, line in enumerate(lines):
    # Lines are 0-indexed, so 389 is line 390.
    if i == 389:
        skip = True
    if i == 535: # line 536 is     }\n (index 535)
        skip = False
    
    if not skip:
        new_lines.append(line)

with open('Components/Pages/Home.razor', 'w', encoding='utf-8') as f:
    f.writelines(new_lines)

print('Lines 390 to 535 explicitly removed.')
