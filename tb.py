with open('temp_card.txt', 'r', encoding='utf-8') as f:
    text = f.read()
    start = text.find('<div class="tek-card')
    inner = text[start:]
    print('inner starts:', inner.count('<div'), 'inner ends:', inner.count('</div'))
