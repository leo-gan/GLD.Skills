# def insertion_sort(ar):
#     for i in range(len(ar)):
#         for ii in range(i, 0, -1):
#             if ar[ii] < ar[ii-1]:
#                 ar[ii], ar[ii-1] = ar[ii-1], ar[ii]
#                 print(ar)

def insertion_sort(ar):
    for i in range(len(ar)):
        for ii in range(i, 0, -1):
            if ar[ii-1] > ar[ii]:
                ar[ii-1], ar[ii] = ar[ii], ar[ii-1]
                print(ar[ii-1], '<->', ar[ii], ar)
import random
def main():
    ar = random.sample(range(1, 100), 20)
    print(ar, '\n')

    insertion_sort(ar)

main()