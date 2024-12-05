rules = dict()
is_filling_rules = True
ok = list()


def read_and_process_file(file_path):
    res = 0
    with open(file_path, 'r') as file:
        for line in file:
            process_line(line)
            
        for i in range(len(ok)):
            ok[i] = sort_list(ok[i])
            
        for element in ok:
            if len(element)%2 == 0:
                res += int(element[len(element)//2])
            else:
                res += int(element[len(element)//2])
                
        print("Part two:")
        print("Result:", res)

def process_line(line):
    global is_filling_rules
    line = line.strip()
    
    if line != "" and is_filling_rules:
        parts = line.split('|')
        key = parts[0]
        values = parts[1]
        if rules.get(key) is None:
            rules[key] = []
        rules[key].append(values)
    
    if line == "":
        is_filling_rules = not is_filling_rules
    
    if line != "" and not is_filling_rules:
        parts = line.split(',')
        element = list()
        is_ok = True
        for i in range(len(parts)):
            elt = parts[i]
            for k in element:
                if rules.get(elt) is not None:
                    for j in rules[elt]:
                        if j == k:
                            is_ok = False
                            break
            element.append(elt)
        
        if not is_ok:
            ok.append(element)
            
def sort_list(li):
    is_ok = False
    while not is_ok:
        i_ok = len(li)
        for i in range(len(li)):
            elt = li[i]
            for k in range(i):
                if rules.get(elt) is not None:
                    for j in rules[elt]:
                        if j == li[k]:
                            i_ok -= 1
                            tmp = li[k]
                            li[k] = li[i]
                            li[i] = tmp
        if i_ok == len(li):
            is_ok = True   
    return li                   


if __name__ == "__main__":
    file_path = "day_5/input"
    read_and_process_file(file_path)
