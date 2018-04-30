def bucket_sort(ar):
    """Returns A sorted. with A = {x : x such that 0 <= x < 1}."""
    buckets = [[] for x in range(10)]
    for i, x in enumerate(ar):
        buckets[int(x * len(buckets))].append(x)
    out = []
    for buck in buckets:
        out += quick_sort(buck)
    print(out)
    return out


# def isort(ar):
#     if len(ar) < 2: return ar
#     i = 1
#     while i < len(ar):
#         k = ar[i]
#         j = i - 1
#         while j >= 0 and ar[j] > k:
#             ar[j + 1], ar[j] = ar[j], k
#             j -= 1
#         i += 1
#     return ar

if __name__ == '__main__':
    import random
    from quick_sort import quick_sort

    def main():
        ar = random.sample(range(0,1000), 20)
        print(ar, '\n')

        bucket_sort(ar)

    main()