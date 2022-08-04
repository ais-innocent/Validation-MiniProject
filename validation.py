# Written by Alireza Alibeiki (https://instagram.com/alireza_alibeiki)

import re

def persian_number_to_english_number(number):
    has_plus = False
    if number.startswith('+'):
        has_plus = True
    try:
        res = str(int(number))
    except:
        return ''
    if has_plus:
        res = '+' + res
    return res

def check_email(email):
    return re.search(r"^[\w\-.]+@([\w-]+\.)+[\w-]{2,4}$", email)

def check_mobile(mobile):
    mobile = persian_number_to_english_number(mobile)
    return re.search(r"^(\+98|0)?(9)(\d){9}$", mobile)

def check_national_code(national_code):
    national_code = persian_number_to_english_number(national_code)
    if not re.search(r"^\d{10}$", national_code): return False
    check = int(national_code[9])
    s = sum(int(national_code[x]) * (10 - x) for x in range(9)) % 11
    return check == s if s < 2 else check + s == 11

def is_valid(exp):
    return 'valid.' if exp else 'not valid.'

email = input('Please enter your email: ')
print('Your email is', is_valid(check_email(email)))

mobile = input('Please enter your phone number: ')
print('Your phone number is', is_valid(check_mobile(mobile)))

national_code = input('Please enter your national code: ')
print('Your national code is', is_valid(check_national_code(national_code)))
