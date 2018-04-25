from stack import Stack
from binary_tree_oo import BinaryTree, preorder, postorder, inorder

def build_parse_tree(fpexp):
    tokens = fpexp.split()
    exp_stack = Stack()
    exp_tree = BinaryTree('')
    exp_stack.push(exp_tree)
    cur_tree = exp_tree

    for token in tokens:
        if token == '(':
            cur_tree.left = ''
            exp_stack.push(cur_tree)
            cur_tree = cur_tree.left
        elif token not in ['+', '-', '*', '/', ')']: # a number
            cur_tree.root = int(token)
            parent = exp_stack.pop()
            cur_tree = parent
        elif token in ['+', '-', '*', '/']:
            cur_tree.root = token
            cur_tree.right = ''
            exp_stack.push(cur_tree)
            cur_tree = cur_tree.right
        elif token == ')':
            cur_tree = exp_stack.pop()
        else:
            raise ValueError
        # print('{}: stack.peek:{} tree:{}-{}-{} cur_tree:{}-{}-{}'.format(token, exp_stack.peek().root,
        #                               exp_tree.left, exp_tree.root, exp_tree.right,
        #                                cur_tree.left, cur_tree.root, cur_tree.right))
        print(token, exp_stack.len())
    return  exp_tree

if __name__ == '__main__':
    exp = '( ( 10 + 5 ) * 3 )'
    pt = build_parse_tree(exp)
    print('\n')
    print(exp)
    preorder(pt)
