class BinarySearchTree:
    def __init__(self):
        self._root = None
        self._size = 0

    def __len__(self):
        return self._size
    def lenght(self):
        return self._size

    def __iter__(self):
        return self._root.__iter()

    def put(self, key, val):
        if self._root:
            self._put(key, val, self._root)
        else:
            self._root = TreeNode(key, val)
        self._size += 1

    def _put(self, key, val, cur_node):
        if key < cur_node._key:
            if cur_node.has_left():
                self._put(key, val, cur_node._left)
            else:
                cur_node._left = TreeNode(key, val)
        elif key == cur_node._key:
            cur_node._val = val
        else:
            if cur_node.has_right():
                self._put(key, val, cur_node._right)
            else:
                cur_node._right = TreeNode(key, val)
    def __setitem__(self, key, value):
        self.put(key, value)

    def get(self, key):
        if self._root:
            res = self._get(key, self._root)
            return res._val if res else None
        else:
            return None

    def _get(self, key, cur_node):
        if not cur_node:
            return None
        elif cur_node._key == key:
            return cur_node
        elif key < cur_node._key:
            return self._get(key, cur_node._left)
        else:
            return self._get(key, cur_node._right)

    def __getitem__(self, key):
        self.get(key)

    def __contains__(self, key):
        return True if self.get(key) else False

class TreeNode:
    def __init__(self, key, val, left=None, right=None, parent=None):
        self._key = key
        self._val = val
        self._left = left
        self._right = right
        self._parent = parent

    def has_left(self):
        return self._left
    def has_right(self):
        return self._right

    def is_left(self):
        return self._parent and self._parent._left == self
    def is_right(self):
        return self._parent and self._parent._right == self

    def is_root(self):
        return self._parent
    def is_leaf(self):
        return not(self._left or self._right)

    def has_any_children(self):
        return self._left or self._right

    def has_both_children(self):
        return self._left and self._right

    def replace_node_data(self, key, val, left, right):
        self._key = key
        self._val = val
        self._left = left
        self._right = right
        if self.has_left():
            self._left._parent = self
        if self.has_right():
            self._right._parent = self

