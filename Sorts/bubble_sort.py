def bubble_sort(ar):
    for i in range(len(ar)):
        for ii in range(len(ar)-i-1):
            if ar[ii] > ar[ii+1]:
                ar[ii], ar[ii+1] = ar[ii+1], ar[ii]
                print(ar)


import random
def main():
    ar = random.sample(range(1,100), 20)
    print(ar,'\n')
    bubble_sort(ar)

main()