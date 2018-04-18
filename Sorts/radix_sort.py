def list_to_baskets(ar, base, position):
    baskets = [[] for b in range(base)]
    for el in ar:
        digit = (el//(base**position))%base
        baskets[digit].append(el)
    print(baskets)
    return baskets

def baskets_to_list(baskets):
    return sum(baskets, [])

import math
def radix_sort(ar):
    base = int(math.sqrt(max(ar)))
    print('base:', base)
    pos = 0 # right side
    print(base**pos, max(ar))
    while (base**(pos)) < max(ar):
        ar = baskets_to_list(list_to_baskets(ar, base, pos))
        pos += 1
        print(pos, ar)
    print(ar)
    return ar

import random
def main():
    ar = random.sample(range(0,1000), 20)
    print(ar, '\n')

    radix_sort(ar)

main()