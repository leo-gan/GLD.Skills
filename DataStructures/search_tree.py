class TreeNode:
    def __init__(self,key,val,left=None,right=None,parent=None):
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

    def isRoot(self):
        return not self._parent

    def isLeaf(self):
        return not (self._right or self._left)

    def hasAnyChildren(self):
        return self._right or self._left

    def has_both_children(self):
        return self._right and self._left

    def replaceNodeData(self,key,value,lc,rc):
        self._key = key
        self._val = value
        self._left = lc
        self._right = rc
        if self.has_left():
            self._left._parent = self
        if self.has_right():
            self._right._parent = self


class BinarySearchTree:

    def __init__(self):
        self._root = None
        self._size = 0

    def length(self):
        return self._size

    def __len__(self):
        return self._size

    def put(self,key,val):
        if self._root:
            self._put(key,val,self._root)
        else:
            self._root = TreeNode(key,val)
        self._size = self._size + 1

    def _put(self,key,val,currentNode):
        if key < currentNode._key:
            if currentNode.has_left():
                   self._put(key,val,currentNode._left)
            else:
                   currentNode._left = TreeNode(key,val,parent=currentNode)
        else:
            if currentNode.has_right():
                   self._put(key,val,currentNode._right)
            else:
                   currentNode._right = TreeNode(key,val,parent=currentNode)

    def __setitem__(self,k,v):
       self.put(k,v)

    def get(self,key):
       if self._root:
           res = self._get(key,self._root)
           if res:
                  return res._val
           else:
                  return None
       else:
           return None

    def _get(self,key,currentNode):
       if not currentNode:
           return None
       elif currentNode._key == key:
           return currentNode
       elif key < currentNode._key:
           return self._get(key,currentNode._left)
       else:
           return self._get(key,currentNode._right)

    def __getitem__(self,key):
       return self.get(key)

    def __contains__(self,key):
       if self._get(key,self._root):
           return True
       else:
           return False

    def delete(self,key):
      if self._size > 1:
         nodeToRemove = self._get(key,self._root)
         if nodeToRemove:
             self.remove(nodeToRemove)
             self._size = self._size-1
         else:
             raise KeyError('Error, key not in tree')
      elif self._size == 1 and self._root._key == key:
         self._root = None
         self._size = self._size - 1
      else:
         raise KeyError('Error, key not in tree')

    def __delitem__(self,key):
       self.delete(key)

    def spliceOut(self):
       if self.isLeaf():
           if self.is_left():
                  self._parent._left = None
           else:
                  self._parent._right = None
       elif self.hasAnyChildren():
           if self.has_left():
                  if self.is_left():
                     self._parent._left = self._left
                  else:
                     self._parent._right = self._left
                  self._left._parent = self._parent
           else:
                  if self.is_left():
                     self._parent._left = self._right
                  else:
                     self._parent._right = self._right
                  self._right._parent = self._parent

    def findSuccessor(self):
      succ = None
      if self.has_right():
          succ = self._right.findMin()
      else:
          if self._parent:
                 if self.is_left():
                     succ = self._parent
                 else:
                     self._parent._right = None
                     succ = self._parent.findSuccessor()
                     self._parent._right = self
      return succ

    def findMin(self):
      current = self
      while current.has_left():
          current = current._left
      return current

    def remove(self, cur_node):
         if cur_node.isLeaf(): #leaf
           if cur_node == cur_node._parent._left:
               cur_node._parent._left = None
           else:
               cur_node._parent._right = None
         elif cur_node.has_both_children(): #interior
           succ = cur_node.findSuccessor()
           succ.spliceOut()
           cur_node._key = succ._key
           cur_node._val = succ._val

         else: # this node has one child
           if cur_node.has_left():
             if cur_node.is_left():
                 cur_node._left._parent = cur_node._parent
                 cur_node._parent._left = cur_node._left
             elif cur_node.is_right():
                 cur_node._left._parent = cur_node._parent
                 cur_node._parent._right = cur_node._left
             else:
                 cur_node.replace_node_data(cur_node._left._key,
                                            cur_node._left._val,
                                            cur_node._left._left,
                                            cur_node._left._right)
           else:
             if cur_node.is_left():
                 cur_node._right._parent = cur_node._parent
                 cur_node._parent._left = cur_node._right
             elif cur_node.is_right():
                 cur_node._right._parent = cur_node._parent
                 cur_node._parent._right = cur_node._right
             else:
                 cur_node.replace_node_data(cur_node._right._key,
                                            cur_node._right._val,
                                            cur_node._right._left,
                                            cur_node._right._right)


if __name__ == '__main__':
    # import random
    # tree = BinarySearchTree()
    #
    # t = random.sample(range(1,100), 20)
    # print(t)
    #
    # [tree.insert(tt) for tt in t]
    # print([tree.del_min() for i in range(len(tree))])
    mytree = BinarySearchTree()
    mytree[3] = "red"
    mytree[4] = "blue"
    mytree[6] = "yellow"
    mytree[2] = "at"

    print(mytree[6])
    print(mytree[2])
