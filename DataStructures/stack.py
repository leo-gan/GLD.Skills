class Stack:
    stack = []
    def __init__(self):
        self.stack = []

    def push(self, val):
        self.stack.append(val)

    def pop(self):
        return self.stack.pop()

    def len(self):
        return len(self.stack)

    def peek(self):
        return self.stack[-1]

    def isEmpty(self):
        return len(self.stack) == 0

if __name__ == '__main__':

    import random
    s = Stack()
    ar = random.sample(range(1,100), 20)
    print('original:', ar)
    [s.push(el) for el in ar]
    print( 'peek:', s.peek())
    print('internal:', s.stack)
    print('pop-s:', [s.pop() for i in range(s.len())])