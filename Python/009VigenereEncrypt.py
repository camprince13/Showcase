import io
import os

path = os.path.join(os.getcwd(), 'SampleData', '004.txt')

inputVar = [line.rstrip('\n') for line in open(path)]

arrLst = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']

def lsToStr(st):
    outy = ''.join(st)
    return outy


def CaesarEncryption(plainText, shift):
    ln = len(plainText)
    ink = 0
    nm = 0
    cipherText = []
    while ink < ln:
        tmp = plainText[ink]
        if arrLst.count(tmp) == 1:
            nm = arrLst.index(tmp)
            nm += shift
            while nm >= len(arrLst):
                nm -= len(arrLst)
            tmp = arrLst[nm]
        cipherText.append(tmp)
        ink += 1
    return cipherText


def CaesarDecryption(plainText, shift):
    ln = len(plainText)
    ink = 0
    nm = 0
    cipherText = []
    while ink < ln:
        tmp = plainText[ink]
        if arrLst.count(tmp) == 1:
            nm = arrLst.index(tmp)
            nm -= shift
            while nm < 0:
                nm += len(arrLst)
            tmp = arrLst[nm]
        cipherText.append(tmp)
        ink += 1
    return cipherText


def encode(key, plainText):  # Vigenère cipher
    cipherText = []
    ink = 0
    while ink < len(plainText):
        keySeed = key[ink % len(key)]
        tmp = CaesarEncryption(plainText[ink], ord(keySeed) % 256)  # chr(ord(string[ink]) + ord(key_c) % 256)
        cipherText.append(tmp)
        #cipherText.  # join(tmp)
        ink += 1
    ink = 0
    outStr = ''
    while ink < len(cipherText):
        outStr += ("".join(cipherText[ink]))   # lsToStr(cipherText)  Breaks here
        ink += 1
    return outStr


def decode(key, plainText):  # Vigenère cipher
    cipherText = []
    ink = 0
    while ink < len(plainText):
        keySeed = key[ink % len(key)]
        tmp = CaesarDecryption(plainText[ink], ord(keySeed) % 256)
        cipherText.append(tmp)
        ink += 1
    ink = 0
    outStr = ''
    while ink < len(cipherText):
        outStr += ("".join(cipherText[ink]))
        ink += 1
    return outStr


def WriteToFile(st):
    outFi = open(os.path.join(os.getcwd(), 'SampleData', '004.encrypted.txt'), 'w')
    outFi.truncate()
    ink = 0
    while ink < len(st):
        outFi.write(st[ink] + '\n')
        ink += 1
    outFi.close()
    return


def OutputStr(st):

    ink = 0
    while ink < len(st):
        print(st[ink])
        ink += 1
    return


print('Before Vigenère Encryption:\n')
print(OutputStr(inputVar))

print('\n\nAfter Vigenère Encryption:\n')

encry = inputVar
ink2 = 0
while ink2 < len(encry):
    encry[ink2] = encode('password1', encry[ink2])
    ink2 += 1
OutputStr(encry)

print('\n\nWriting to file...')
WriteToFile(encry)
print('Done!')

print('Decrypting...\n')
ink2 = 0
while ink2 < len(encry):
    encry[ink2] = decode('password1', encry[ink2])
    ink2 += 1
OutputStr(encry)
