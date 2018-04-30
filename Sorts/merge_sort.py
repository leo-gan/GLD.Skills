def merge_sort(x):

    if len(x) < 2: return x

    result, mid = [], int(len(x) / 2)

    y, z = merge_sort(x[:mid]), merge_sort(x[mid:])

    while (len(y) > 0) and (len(z) > 0):
        t = z if z[0] < y[0] else y
        #print(t[0])
        result.append(t.pop(0))
    print(result, y, z)
    return result + y + z

def mergeSort(ar):
    print('S:', ar)
    if len(ar)>1:
        mid = len(ar) // 2
        lefthalf = ar[:mid]
        righthalf = ar[mid:]

        mergeSort(lefthalf)
        mergeSort(righthalf)

        i, j, k = 0, 0, 0
        while i < len(lefthalf) and j < len(righthalf):
            if lefthalf[i] < righthalf[j]:
                ar[k]=lefthalf[i]
                i += 1
            else:
                ar[k]=righthalf[j]
                j += 1
            k += 1

        while i < len(lefthalf):
            ar[k]=lefthalf[i]
            i += 1
            k += 1
        #ar[k:(k+len(lefthalf))] = lefthalf[i:]

        while j < len(righthalf):
            ar[k]=righthalf[j]
            j += 1
            k += 1
        # ar[k:(k + len(righthalf))] = righthalf[j:]
    print("M:", ar)



import random
def main():
    ar = random.sample(range(1,100),20)
    print(ar,'\n')

    print(merge_sort(ar))
    #print(mergeSort(ar))

main()