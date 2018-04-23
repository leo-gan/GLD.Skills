class BinaryTree:
    def __init__(self, obj):
        self._key = obj
        self._left = None
        self._right = None

    def get_root(self):
        return self._key
    def set_root(self, obj):
        self._key = obj
    # def del_root(self):
    #     self.key = None
    root = property(get_root, set_root, None, 'A root of the Binary Tree.')

    def get_left(self):
        return self._left
    def set_left(self, obj):
        tmp = BinaryTree(obj)
        if self._left != None:
            tmp.left = self._left
        self._left = tmp
    # def del_left(self):
    #     self.left = None
    left = property(get_left, set_left, None, 'A left branch of the Binary Tree.')

    def get_right(self):
        return self._right
    def set_right(self, obj):
        tmp = BinaryTree(obj)
        if self._right != None:
            tmp.right = self._right
        self._right = tmp

    # def del_right(self):
    #     self.right = None
    right = property(get_right, set_right, None, 'A right branch of the Binary Tree.')

if __name__ == '__main__':
    r = BinaryTree('a')
    print(r.root, r.left, r.right)
    r.left = 'b'
    print(r.root, r.left.root, r.right)
    r.right = 'c'
    print(r.root, r.left.root, r.right.root)
    r_right = r.right
    r_right.root = 'hello'
    print(r.root, r.left.root, r.right.root)

                    