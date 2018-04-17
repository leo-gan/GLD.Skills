def quick_sort(ar):

    if not ar: return ar # empty sequence case
    #pivot = ar[random.choice(range(0, len(ar)))]
    pivot = ar[0]

    head = quick_sort([elem for elem in ar if elem < pivot])
    tail = quick_sort([elem for elem in ar if elem > pivot])
    print(pivot, head, [elem for elem in ar if elem == pivot], tail)
    return head + [elem for elem in ar if elem == pivot] + tail

import random
# def qsort(ar):
#     if not ar: return ar
#     pivot = ar[random.choice(range(len(ar)))]  # ar[0] #
#
#     head = qsort([el for el in ar if el < pivot])
#     tail = qsort([el for el in ar if el > pivot])
#     return head + [el for el in ar if el == pivot] + tail

import random
def quick_srt(ar):
    if len(ar) < 2: return ar
    pivot = ar[0]
    head = [el for el in ar if el < pivot]
    middle = [el for el in ar if el == pivot]
    tail = [el for el in ar if el > pivot]
    print('   >',  pivot, head, middle, tail)
    head = quick_srt(head)
    tail = quick_srt(tail)
    print('     <', pivot, head, middle, tail)
    return head + middle + tail
import random
def main():
    ar = random.sample(range(10, 100), 20)
    print(ar, '\n')
    # print(quick_sort(ar), '\n')
    # print(qsort(ar))
    print(quick_srt(ar))

main()