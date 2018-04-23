def BinaryTree(r):
    return [r, [], []]

def insert_left(root, new_branch):
    #print('insert_left() root:', root)
    assert len(root) == 3
    old_branch = root.pop(1)
    if len(old_branch) < 2: # should be < 1 ?
        old_branch = []
    root.insert(1, [new_branch, old_branch, []])

def insert_right(root, new_branch):
    #print('insert_right() root:', root)
    assert len(root) == 3
    old_branch = root.pop(2)
    if len(old_branch) < 2: # should be < 1 ?
        old_branch = []
    root.insert(2, [new_branch, [], old_branch])

def get_root(bt):
    return bt[0]

def get_left(bt):
    return bt[1]

def get_right(bt):
    return bt[2]

if __name__ == '__main__':
    bt = BinaryTree(1)
    insert_left(bt, 2)
    insert_right(bt, 3)
    print(bt)
    print(get_root(bt), get_left(bt), get_right(bt))

    x = BinaryTree('a')
    insert_left(x,'b')
    insert_right(x,'c')
    insert_right(get_right(x),'d')
    insert_left(get_right(get_right(x)),'e')
    print(x)

    a = BinaryTree('a')
    insert_left(a, 'b')
    insert_right(a, 'c')
    insert_right(get_left(a), 'd')
    insert_right(get_right(a), 'f')
    insert_left(get_right(a), 'e')
    print(a)