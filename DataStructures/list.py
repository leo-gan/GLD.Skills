class Node:
    def __init__(self, init_val=None):
        self._data = init_val
        self._next = None

    @property
    def data(self):
        '''A value, stored in this Node object.'''
        return self._data

    @data.setter
    def data(self, val):
        self._data = val

    @data.deleter
    def data(self):
        self._data = None

    @property
    def next(self):
        '''A linked Node object.'''
        return self._next
    @next.setter
    def next(self, val):
        self._next = val
    @next.deleter
    def next(self):
        self._next = None

class UnorderedList:
    def __init__(self):
        self._head = None # Node()
    def _get_last_node(self):
        if self._head == None:
            return None
        cur = self._head
        while cur.next != None:
            cur = cur.next
        return cur

    def search(self, val):
        cur = self._head
        while cur != None:
            if cur.data.data == val:
                return True
            cur = cur.next
        return False

    def add(self, val):
        tmp = Node(val)
        tmp.next = self._head
        self._head = tmp

    def remove(self, item):
        if self._head == None:
            return False
        if self._head.data.data == item:
            self._head = self._head.next
            return True
        prev = cur = self._head
        while cur != None:
            if cur.data.data == item:
                prev.next = cur.next
                return True
            prev, cur = cur, cur.next
        return False

    def size(self):
        s = 0
        cur = self._head
        while cur != None:
            s +=1
            cur = cur.next
        return s

    def isEmpty(self):
        return self._head == None

    def print(self):
        cur = self._head
        print('UnorderedList: size =', self.size(), end=': ')
        if cur == None:
            print('Empty')
            return
        print('->', cur.data.data, end=' ')
        while cur.next != None:
            cur = cur.next
            print('->', cur.data.data, end=' ')
        print('')


lst = Node(5)
print(lst._data, lst.data)
nxt = Node(23)
lst.next = nxt
print(lst.data, lst.next.data)

ul = UnorderedList()
ul.print()
ul.add(Node(1))
ul.print()
ul.add(Node(2))
ul.print()
ul.add(Node(3))
ul.print()
ul.add(Node(4))
ul.print()
_ = [print('search({})={}'.format(i, ul.search(i))) for i in range(ul.size()+2)]

ul.print()
ul.remove(2)
print('removed', 2, end=' : ')
ul.print()
ul.remove(1)
print('removed', 1, end=' : ')
ul.print()
ul.remove(4)
print('removed', 4, end=' : ')
ul.print()
ul.remove(3)
print('removed', 3, end=' : ')
ul.print()
ul.remove(3)
print('removed', 3, end=' : ')
ul.print()

