class BinHeap:
    '''The min-heap. The min element is always on the top of the heap.'''
    def __init__(self):
        self._heap = [0]
        self._cur_size = 0

    def _perc_up(self, i):
        while i//2 > 0:
            if self._heap[i] < self._heap[i//2]:
                self._heap[i], self._heap[i//2] = self._heap[i//2], self._heap[i]
            i = i//2

    def _perc_down(self, i):
        while (i*2) <= self._cur_size:
            min_child_idx = self._min_child(i)
            if self._heap[i] > self._heap[min_child_idx]:
                self._heap[i], self._heap[min_child_idx] = self._heap[min_child_idx], self._heap[i]
            i = min_child_idx

    def _min_child(self, i):
        if i*2 + 1 > self._cur_size: # only one child
            return i*2
        else:
            if self._heap[i*2] < self._heap[i*2+1]:
                return i*2
            else:
                return i*2+1

    def insert(self, item):
        self._heap.append(item)
        self._cur_size += 1
        self._perc_up(self._cur_size)

    def find_min(self):
        if self._cur_size == 0:
            return None
        return self._heap[1]

    def del_min(self):
        top = self._heap[1]
        self._heap[1] = self._heap[self._cur_size]
        self._cur_size -= 1
        self._heap.pop()
        self._perc_down(1)
        return top

    def is_empty(self):
        return False if self._cur_size >0 else True

    def size(self):
        return self._cur_size

    def build_heap(self, added_list):
        self._heap = [0] + added_list[:]
        self._cur_size = len(added_list)

        i = len(added_list) // 2
        while i>0:
            self._perc_down(i)
            i -= 1


if __name__ == '__main__':
    import random
    heap = BinHeap()

    t = random.sample(range(1,100), 20)
    print(t)

    [heap.insert(tt) for tt in t]

    print([heap.del_min() for i in range(heap.size())])
