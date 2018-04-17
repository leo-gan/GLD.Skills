# def selection_sort(ar):
#     for i in range(len(ar)):
#         max_id = 0
#         for ii in range(len(ar)-i):
#             if ar[ii] > ar[max_id]:
#                 max_id = ii
#         ar[len(ar)-i-1], ar[max_id] = ar[max_id], ar[len(ar)-i-1]
#         print(ar)

def selection_sort(ar):
    for i in range(len(ar)):
        max_ii = 0
        for ii in range(len(ar)-i):
            if ar[ii] > ar[max_ii]:
                max_ii = ii
        if ar[max_ii] > ar[len(ar)-i-1]:
            ar[max_ii], ar[len(ar)-i-1] = ar[len(ar)-i-1], ar[max_ii]
            print(ar[max_ii], '<=>', ar[len(ar)-i-1], ar)

import random
def main():
    ar = random.sample(range(1,100),20)
    print(ar, '\n')
    selection_sort(ar)

main()