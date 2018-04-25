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

class BinaryHeap:
    def __init__(self):
        self._heap = [0]
        self._size = 0

    def insert(self, item):
        self._heap.append(item)
        self._size += 1
        self._percolate_up(self._size)

    def _percolate_up(self, i):
        while i//2 > 0:
            if self._heap[i] > self._heap[i//2]:
                return
            self._heap[i], self._heap[i//2] = self._heap[i//2], self._heap[i]
            i = i//2

    def size(self):
        return self._size

    def del_min(self):
        if self._size == 0:
            return None
        temp = self._heap[1]
        self._heap[1] = self._heap[self._size]
        self._size -= 1
        self._heap.pop()
        self._percolate_down(1)
        return temp

    def _percolate_down(self, i):
        while i*2 <= self._size:
            min_child_idx = self.min_child(i)
            if self._heap[i] < self._heap[min_child_idx]: return
            self._heap[i], self._heap[min_child_idx] = self._heap[min_child_idx], self._heap[i]
            i = min_child_idx

    def is_empty(self):
        return False if self._size > 0 else True

    def min_child(self, i):
        if self._size <= 2*i:
            return 2*i
        else:
            return 2*i if self._heap[2*i] < self._heap[2*i+1] else 2*i+1

    def find_min(self):
        return self._heap[1]

if __name__ == '__main__':
    import random
    heap = BinHeap()

    t = random.sample(range(1,100), 20)
    print(t)

    [heap.insert(tt) for tt in t]
    print([heap.del_min() for i in range(heap.size())])

    heap = BinHeap()
    heap.build_heap(t)
    print([heap.del_min() for i in range(heap.size())])

    heap = BinaryHeap()
    [heap.insert(tt) for tt in t]
    print([heap.del_min() for i in range(heap.size())])
