class Node:
    def __init__(self, init_val=None):
        self._data = init_val
        self._next = None
    #
    # @property
    # def data(self):
    #     '''A value, stored in this Node object.'''
    #     return self._data
    #
    # @data.setter
    # def data(self, val):
    #     self._data = val
    #
    # @data.deleter
    # def data(self):
    #     self._data = None
    #
    # @property
    # def next(self):
    #     '''A linked Node object.'''
    #     return self._next
    # @next.setter
    # def next(self, val):
    #     self._next = val
    # @next.deleter
    # def next(self):
    #     self._next = None
    def set_data(self, data):
        self._data = data
    def get_data(self):
        return self._data
    def del_data(self):
        self._data = None
    data = property(get_data, set_data, del_data, 'A value, stored in this Node object.')

    def set_next(self, next):
        self._next = next
    def get_next(self):
        return self._next
    def del_next(self):
        self._next = None
    next = property(get_next, set_next, del_next, 'A linked Node object.')

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
            if cur.data == val:
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
        if self._head.data == item:
        #if self._head.get_data().get_data() == item:
            self._head = self._head.next
            return True
        prev = cur = self._head
        while cur != None:
            if cur.data == item:
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
        print('->', cur.data, end=' ')
        while cur.next != None:
            cur = cur.next
            print('->', cur.data, end=' ')
        print('')

if __name__ == '__main__':

    lst = Node(5)
    print(lst._data, lst.data)
    nxt = Node(23)
    lst.next = nxt
    print(lst.data, lst.next.data)

    ul = UnorderedList()
    ul.print()
    ul.add(3)
    ul.print()
    ul.add(1)
    ul.print()
    ul.add(4)
    ul.print()
    ul.add(2)
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

