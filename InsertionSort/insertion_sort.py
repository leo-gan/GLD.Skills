def insertion_sort(ar):
    for i in range(len(ar)+1):
        for ii in range(i-1, 0, -1):
            if ar[ii] < ar[ii-1]:
                ar[ii], ar[ii-1] = ar[ii-1], ar[ii]
                print(ar)

import random
def main():
    ar = random.sample(range(1, 100), 20)
    print(ar, '\n')

    insertion_sort(ar)

main()