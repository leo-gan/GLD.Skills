class Queue:
    store = []
    def __init__(self):
        self.store = []
    def enqueue(self, val):
        self.store.insert(0, val)
    def dequeue(self):
        return self.store.pop()
    def peek(self):
        return self.store[-1]
    def size(self):
        return len(self.store)
    def isEmpty(self):
        return len(self.store) == 0

if __name__ == '__main__':
    import random
    ar = random.sample(range(1, 1000), 20)
    print('original:', ar)
    q = Queue()
    [q.enqueue(el) for el in ar]
    print('queue.store:', q.store)
    print('peek()', q.peek())
    deq = []
    for i in range(q.size()):
        print('dequeued:', q.dequeue())
    print('dequeued store:', q.store)
