# https://github.com/zhiwehu/Python-programming-exercises/blob/master/100%2B%20Python%20challenging%20programming%20exercises.txt
import math
from functools import reduce
from operator import itemgetter
import re

# 1
# print(*[x for x in range(2000, 3201) if x % 7 == 0 and x % 5 != 0])

# 2
# print(math.factorial(8))
# print(reduce(lambda x, y: x * y, range(1, 8+1)))

# 3
# print({x: x*x for x in range(1, 8)})

# 4
# print(list(input().split(',')))


# 5
# class five:
#     def getString(self):
#         return 'test'

#     def printString(self, s):
#         print(s)


# f = five()
# f.getString()
# f.printString('a')


# 6
# i = list(map(int, '100,150,180'.split(',')))

# print(*[int(math.sqrt((2*50*x)/30)) for x in i])


# 7

# x, y = 3, 5
# print(*[[i*j for j in range(y)] for i in range(x)])

# 8

# w = 'without,hello,bag,world'.split(',')
# print(','.join(sorted(w)))


# 9
# w = '''Hello world
# Practice makes perfect'''
# print(w.upper())


# 10

# w = 'hello world and practice makes perfect and hello world again'
# w = set(w.split(' '))
# print(" ".join(sorted(w)))


# 11

# n = '0100,0011,1010,1001'.split(',')
# print(*[x for x in n if int(x, 2) % 5 == 0])


# 12

# print(*[x for x in range(1000, 3001) if not any(c in '13579' for c in str(x))])


# 13

# w = 'hello world! 123'
# print(sum([1 for x in w if x.isalpha()]))
# print(sum([1 for x in w if x.isdigit()]))

# 18

# w = 'ABd1234@1,a F1#,2w3E*,2We3345'.split(',')
# o = filter(lambda x: re.search(
#     '[a-z]', x) and re.search('[A-Z]', x) and re.search('[0-9]', x)
#     and re.search('[$#@]', x) and len(x) > 5 and len(x) < 13, w)
# print(list(o))

# 19

# people = [('Tom', 19, 80), ('John', 20, 90), ('Jony', 17, 91),
#           ('Jony', 17, 93), ('Json', 21, 85)]
# print(sorted(people, key=itemgetter(0, 1, 2)))


# 20
# def getNumbers(n):
#     yield ([x for x in range(n) if x % 7 == 0])


# for i in getNumbers(100):
#     print(i)


# 22
from collections import Counter

w = 'New to Python or choosing between Python 2 and Python 3? Read Python 2 or Python 3.'.split()
for k, v in sorted(Counter(w).items(), key=lambda pair: pair[0]):
    print('%s:%d' % (k, v))
