# https://programmingwithmosh.com/python/python-exercises-and-questions-for-beginners/


def FizzBuzz(num):
    if(num % 15 == 0):
        return "FizzBuzz"
    elif(num % 5 == 0):
        return "Buzz"
    elif(num % 3 == 0):
        return "Fizz"
    else:
        return num


# for i in range(1, 101):
#     print(FizzBuzz(i))


def MaxTwoNumbers(num1, num2):
    return max(num1, num2)


# print(MaxTwoNumbers(1, 2))


def DriverSpeed(speed):
    if speed < 70:
        return "OK"
    elif speed >= 135:
        return "License suspended"
    return f"Points: {int((speed - 70) / 5)}"


# for i in range(6, 140, 6):
#     print(DriverSpeed(i))

def showNumbers(limit):
    for i in range(limit):
        word = "EVEN" if (i % 2 == 0) else "ODD"
        print(str(i) + " " + word)


# showNumbers(8)


def SumThreeAndFive(limit):
    return sum(i for i in range(1, limit+1) if i % 3 == 0 or i % 5 == 0)


# print(SumThreeAndFive(5))


def show_stars(rows):
    for i in range(1, rows+1):
        print("*"*i)


# show_stars(5)


def primeNumbers(limit):
    for i in range(limit+1):
        if isPrime(i):
            print(i)


def isPrime(i) -> bool:
    for j in range(2, i):
        if(i % j == 0):
            return False
    return True


# primeNumbers(20)


print(*list(i for i in range(20+1) if isPrime(i)))
