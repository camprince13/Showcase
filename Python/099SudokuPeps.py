import io
import os

path = os.path.join(os.getcwd(), 'SampleData', 'sudoku5.txt')

SudLines = [line.rstrip('\n') for line in open(path)]
numList = ['1', '2', '3', '4', '5', '6', '7', '8', '9']

Char0 = list(SudLines[0])
Char1 = list(SudLines[1])
Char2 = list(SudLines[2])
Char3 = list(SudLines[3])
Char4 = list(SudLines[4])
Char5 = list(SudLines[5])
Char6 = list(SudLines[6])
Char7 = list(SudLines[7])
Char8 = list(SudLines[8])

solved = 'false'
stale = 0  # used to put a limit on the amount of cell checks allowed


def updateChars(l):
    global Char0
    Char0 = list(l[0])
    global Char1
    Char1 = list(l[1])
    global Char2
    Char2 = list(l[2])
    global Char3
    Char3 = list(l[3])
    global Char4
    Char4 = list(l[4])
    global Char5
    Char5 = list(l[5])
    global Char6
    Char6 = list(l[6])
    global Char7
    Char7 = list(l[7])
    global Char8
    Char8 = list(l[8])
    return


def printFormat():

    updateChars(SudLines)
    print('+-----------+')
    print('|' + Char0[0] + Char0[1] + Char0[2] + '|' + Char1[0] + Char1[1] + Char1[2] + '|' + Char2[0] + Char2[1] + Char2[2] + '|')
    print('|' + Char0[3] + Char0[4] + Char0[5] + '|' + Char1[3] + Char1[4] + Char1[5] + '|' + Char2[3] + Char2[4] + Char2[5] + '|')
    print('|' + Char0[6] + Char0[7] + Char0[8] + '|' + Char1[6] + Char1[7] + Char1[8] + '|' + Char2[6] + Char2[7] + Char2[8] + '|')
    print('+---|---|---+')
    print('|' + Char3[0] + Char3[1] + Char3[2] + '|' + Char4[0] + Char4[1] + Char4[2] + '|' + Char5[0] + Char5[1] + Char5[2] + '|')
    print('|' + Char3[3] + Char3[4] + Char3[5] + '|' + Char4[3] + Char4[4] + Char4[5] + '|' + Char5[3] + Char5[4] + Char5[5] + '|')
    print('|' + Char3[6] + Char3[7] + Char3[8] + '|' + Char4[6] + Char4[7] + Char4[8] + '|' + Char5[6] + Char5[7] + Char5[8] + '|')
    print('+---|---|---+')
    print('|' + Char6[0] + Char6[1] + Char6[2] + '|' + Char7[0] + Char7[1] + Char7[2] + '|' + Char8[0] + Char8[1] + Char8[2] + '|')
    print('|' + Char6[3] + Char6[4] + Char6[5] + '|' + Char7[3] + Char7[4] + Char7[5] + '|' + Char8[3] + Char8[4] + Char8[5] + '|')
    print('|' + Char6[6] + Char6[7] + Char6[8] + '|' + Char7[6] + Char7[7] + Char7[8] + '|' + Char8[6] + Char8[7] + Char8[8] + '|')
    print('+-----------+')
    return


def retSingleCell(num):
    updateChars(SudLines)
    num = int(num)
    if num == 1:
        return Char0
    elif num == 2:
        return Char1
    elif num == 3:
        return Char2
    elif num == 4:
        return Char3
    elif num == 5:
        return Char4
    elif num == 6:
        return Char5
    elif num == 7:
        return Char6
    elif num == 8:
        return Char7
    elif num == 9:
        return Char8
    else:
        return


def quickDel(cell, n1, n2, n3):
    del cell[n1]
    del cell[n1]
    del cell[n2]
    del cell[n2]
    del cell[n3]
    del cell[n3]
    return cell


def quickDelV2(cell):  # for midd col
    del cell[0]
    del cell[1]
    del cell[1]
    del cell[2]
    del cell[2]
    del cell[3]
    return cell


def quickDelV3(cell, n1, n2):  # for row
    del cell[n1]
    del cell[n1]
    del cell[n1]
    del cell[n2]
    del cell[n2]
    del cell[n2]
    return cell


def quickColumn(cl1, currPos):
    if currPos == 1 or currPos == 4 or currPos == 7:
        cl1 = quickDel(cl1, 1, 2, 3)
        return cl1
    elif currPos == 2 or currPos == 5 or currPos == 8:
        cl1 = quickDelV2(cl1)
        return cl1
    elif currPos == 3 or currPos == 6 or currPos == 9:
        cl1 = quickDel(cl1, 0, 1, 2)
        return cl1
    else:
        return 0


def retNumAtPos(cellNum, pos):
    cellNum = retSingleCell(cellNum)
    return (cellNum[(int(pos) - 1)])


def cellContains(cell, num):
    if cell.count(str(num)) > 0:
        return 'true'
    else:
        return 'false'


def countBlankSquares(cell):
    return cell.count('0')


def totalBlankSquares():
    count = 0
    ink = 1
    while ink <= 9:
        count += retSingleCell(ink).count('0')
        ink += 1
    print('There are ' + str(count) + ' blank cells left')
    if count == 0:
        print('Sudoku solved!')
        global solved
        solved = 'true'
        global stale
        stale = 0
    return


# override/update a cell
def CellEdit(cell, cellNum):
    global stale
    stale = 0
    global SudLines
    SudLines[(cellNum - 1)] = cell
    printFormat()
    totalBlankSquares()
    return


#  check cell above and below for num
def checkCellAboveBelow(currentCell, num):
    output = 0
    inx = currentCell + 3
    if inx > 9:
        inx = inx - 9
    tmpCell = retSingleCell(inx)
    output += tmpCell.count(str(num))
    inx = inx + 3
    if inx > 9:
        inx = inx - 9
    tmpCell = retSingleCell(inx)
    output += tmpCell.count(str(num))
    return output


#  check cell left and right for num
def checkCellLeftRight(currentCell, num):
    count = 0
    #  if 1, 4, 7
    if currentCell == 1 or currentCell == 4 or currentCell == 7:
        count += retSingleCell((currentCell + 1)).count(str(num))
        count += retSingleCell((currentCell + 2)).count(str(num))

    #  if 2, 5, 8
    elif currentCell == 2 or currentCell == 5 or currentCell == 8:
        count += retSingleCell((currentCell - 1)).count(str(num))
        count += retSingleCell((currentCell + 1)).count(str(num))

    #  if 3, 6, 9
    elif currentCell == 3 or currentCell == 6 or currentCell == 9:
        count += retSingleCell((currentCell - 1)).count(str(num))
        count += retSingleCell((currentCell - 2)).count(str(num))
    return count


#  check column for num
def checkColumn(currPos, currCell, num):
    Count = 0
    c1 = ''
    c2 = ''
    c3 = ''

    def insider(cl1, cl2, cl3, count):
        if currPos == 1 or currPos == 4 or currPos == 7:
            cl1 = quickDel(cl1, 1, 2, 3)
            cl2 = quickDel(cl2, 1, 2, 3)
            cl3 = quickDel(cl3, 1, 2, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 2 or currPos == 5 or currPos == 8:
            cl1 = quickDelV2(cl1)
            cl2 = quickDelV2(cl2)
            cl3 = quickDelV2(cl3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 3 or currPos == 6 or currPos == 9:
            cl1 = quickDel(cl1, 0, 1, 2)
            cl2 = quickDel(cl2, 0, 1, 2)
            cl3 = quickDel(cl3, 0, 1, 2)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        else:
            return 0
        #  end insider

    if currCell == 1 or currCell == 4 or currCell == 7:
        c1 = retSingleCell(1)
        c2 = retSingleCell(4)
        c3 = retSingleCell(7)
        return insider(c1, c2, c3, Count)
    elif currCell == 2 or currCell == 5 or currCell == 8:
        c1 = retSingleCell(2)
        c2 = retSingleCell(5)
        c3 = retSingleCell(8)
        return insider(c1, c2, c3, Count)
    elif currCell == 3 or currCell == 6 or currCell == 9:
        c1 = retSingleCell(3)
        c2 = retSingleCell(6)
        c3 = retSingleCell(9)
        return insider(c1, c2, c3, Count)
    else:
        return 0
    #  end checkColumn


def checkCellsCol(currPos, currCell, num):

    cl = retSingleCell(currCell)
    Count = 0

    def insider(cl1, count):
        if currPos == 1 or currPos == 4 or currPos == 7:
            cl1 = quickDel(cl1, 1, 2, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 2 or currPos == 5 or currPos == 8:
            cl1 = quickDelV2(cl1)
            count += cl1.count(str(num))
            return count
        elif currPos == 3 or currPos == 6 or currPos == 9:
            cl1 = quickDel(cl1, 0, 1, 2)
            count += cl1.count(str(num))
            return count
        else:
            return 0

    return insider(cl, Count)


#  check row for num
def checkRow(currPos, currCell, num):

    Count = 0
    c1 = ''
    c2 = ''
    c3 = ''

    def insider(cl1, cl2, cl3, count):
        if currPos == 1 or currPos == 2 or currPos == 3:
            cl1 = quickDelV3(cl1, 3, 3)
            cl2 = quickDelV3(cl2, 3, 3)
            cl3 = quickDelV3(cl3, 3, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 4 or currPos == 5 or currPos == 6:
            cl1 = quickDelV3(cl1, 0, 3)
            cl2 = quickDelV3(cl2, 0, 3)
            cl3 = quickDelV3(cl3, 0, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 7 or currPos == 8 or currPos == 9:
            cl1 = quickDelV3(cl1, 0, 0)
            cl2 = quickDelV3(cl2, 0, 0)
            cl3 = quickDelV3(cl3, 0, 0)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        else:
            return 0
        #  end insider

    if currCell == 1 or currCell == 2 or currCell == 3:
        c1 = retSingleCell(1)
        c2 = retSingleCell(2)
        c3 = retSingleCell(3)
        return insider(c1, c2, c3, Count)
    elif currCell == 4 or currCell == 5 or currCell == 6:
        c1 = retSingleCell(4)
        c2 = retSingleCell(5)
        c3 = retSingleCell(6)
        return insider(c1, c2, c3, Count)
    elif currCell == 7 or currCell == 8 or currCell == 9:
        c1 = retSingleCell(7)
        c2 = retSingleCell(8)
        c3 = retSingleCell(9)
        return insider(c1, c2, c3, Count)
    else:
        return 0

    return
    #  end check row


def checkCellsRow(currPos, currCell, num):

    cl = retSingleCell(currCell)
    Count = 0

    def insider(cl1, count):
        if currPos == 1 or currPos == 2 or currPos == 3:
            cl1 = quickDelV3(cl1, 3, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 4 or currPos == 5 or currPos == 6:
            cl1 = quickDelV3(cl1, 0, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 7 or currPos == 8 or currPos == 9:
            cl1 = quickDelV3(cl1, 0, 0)
            count += cl1.count(str(num))
            return count
        else:
            return 0

    return insider(cl, Count)


def twoUDtwoLRColNoRowNo(currentCell, currentPos, checkNum):
    outy = 'false'
    if checkCellAboveBelow(currentCell, checkNum) == 2:
        if checkCellLeftRight(currentCell, checkNum) == 2:
            if checkColumn(currentPos, currentCell, checkNum) == 0:
                if checkRow(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def twoUD1BlankInCol(currentCell, currentPos, checkNum):
    outy = 'false'
    if checkCellAboveBelow(currentCell, checkNum) == 2:
        if checkColumn(currentPos, currentCell, checkNum) == 0:
            if checkCellsCol(currentPos, currentCell, checkNum) == 0:
                if checkCellsCol(currentPos, currentCell, 0) == 1:
                    outy = 'true'
    return outy


def twoLR1BlankInRow(currentCell, currentPos, checkNum):
    outy = 'false'
    if checkCellLeftRight(currentCell, checkNum) == 2:
        if checkRow(currentPos, currentCell, checkNum) == 0:
            if checkCellsRow(currentPos, currentCell, 0) == 1:
                outy = 'true'
    return outy


def twoUD1LRMultAvail(currentCell, currentPos, checkNum):
    outy = 'false'
    if checkCellAboveBelow(currentCell, checkNum) == 2:
        if checkCellLeftRight(currentCell, checkNum) == 1:
            if checkColumn(currentPos, currentCell, checkNum) == 0:
                if checkRow(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def twoLR1UDMultAvail(currentCell, currentPos, checkNum):
    outy = 'false'
    if checkCellLeftRight(currentCell, checkNum) == 2:
        if checkCellAboveBelow(currentCell, checkNum) == 1:
            if checkRow(currentPos, currentCell, checkNum) == 0:
                if checkColumn(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def shorter2LR1UDMult(currentCell, currentPos, checkNum):
    outy = 'false'
    if twoUD1LRMultAvail(currentCell, currentPos, checkNum) == 'true':
        if checkCellsCol(currentPos, currentCell, 0) == 2:
            tmpCk = currentPos + 3
            if tmpCk > 9:
                tmpCk -= 9
            if retNumAtPos(currentCell, tmpCk) == '0':
                if checkRow(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter2LR1UDMultv2(currentCell, currentPos, checkNum):
    outy = 'false'
    if twoUD1LRMultAvail(currentCell, currentPos, checkNum) == 'true':
        if checkCellsCol(currentPos, currentCell, 0) == 2:
            tmpCk = currentPos + 6
            if tmpCk > 9:
                tmpCk -= 9
            if retNumAtPos(currentCell, tmpCk) == '0':
                if checkRow(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter2UD1LRMult(currentCell, currentPos, checkNum):
    outy = 'false'
    if twoLR1UDMultAvail(currentCell, currentPos, checkNum) == 'true':
        if checkCellsRow(currentPos, currentCell, 0) == 2:
            tmpCk = 1

            if currentPos == 1 or currentPos == 4 or currentPos == 7:
                tmpCk = currentPos + 1
            elif currentPos == 2 or currentPos == 5 or currentPos == 8:
                tmpCk = currentPos + 1
            elif currentPos == 3 or currentPos == 6 or currentPos == 9:
                tmpCk = currentPos - 2
            if retNumAtPos(currentCell, tmpCk) == '0':
                if checkColumn(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter2UD1LRMultv2(currentCell, currentPos, checkNum):
    outy = 'false'
    if twoLR1UDMultAvail(currentCell, currentPos, checkNum) == 'true':
        if checkCellsRow(currentPos, currentCell, 0) == 2:
            tmpCk = 1

            if currentPos == 1 or currentPos == 4 or currentPos == 7:
                tmpCk = currentPos + 1
            elif currentPos == 2 or currentPos == 5 or currentPos == 8:
                tmpCk = currentPos + 1
            elif currentPos == 3 or currentPos == 6 or currentPos == 9:
                tmpCk = currentPos - 2

            if tmpCk == 1 or tmpCk == 4 or tmpCk == 7:
                tmpCk = tmpCk + 1
            elif tmpCk == 2 or tmpCk == 5 or tmpCk == 8:
                tmpCk = tmpCk + 1
            elif tmpCk == 3 or tmpCk == 6 or tmpCk == 9:
                tmpCk = tmpCk - 2

            if retNumAtPos(currentCell, tmpCk) == '0':
                if checkColumn(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def solve(currentPos, currentCell):

    checkNum = 1

    if currentPos > 9:
        currentPos = 1
        currentCell += 1
    if currentCell > 9:
        currentCell = 1
    if checkNum > 9:
        checkNum = 1

    #  if cell is not missing any numbers
    if cellContains(retSingleCell(currentCell), 0) == 'false':
        currentCell += 1
        currentPos = 1

    #  if cell is only missing 1 number
    elif countBlankSquares(retSingleCell(currentCell)) == 1:
        tmpCell = retSingleCell(currentCell)
        tmpNmList = ['1', '2', '3', '4', '5', '6', '7', '8', '9']
        ink = 1
        while cellContains(tmpCell, 0) == 'true':
            if len(tmpNmList) > 1 and ink <= 9:
                if cellContains(tmpCell, ink) == 'true':
                    del tmpNmList[tmpNmList.index(str(ink))]
                ink += 1
            else:
                i = tmpCell.index('0')
                tmpCell[i] = tmpNmList[0]
                CellEdit(tmpCell, currentCell)
                tmpNmList = ['1', '2', '3', '4', '5', '6', '7', '8', '9']
                ink = 1
        done = 1
    #  end if cell is only missing 1 number

    #  more than 1 missing number --v

    #  if current num is not missing
    elif retNumAtPos(currentCell, currentPos) != '0':
        currentPos += 1

    #  current number in current cell is 0
    else:

        while checkNum <= 9:

            if cellContains(retSingleCell(currentCell), checkNum) == 'true':
                checkNum += 1
            else:

                #  if 2 vert, 2 horizontal, and 1 available
                #  if checkCellAboveBelow(currentCell, checkNum) == 2 and checkCellLeftRight(currentCell, checkNum) == 2 and checkColumn(currentPos, currentCell, checkNum) == 0 and checkRow(currentPos, currentCell, checkNum) == 0:
                if twoUDtwoLRColNoRowNo(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10
##
                # if 2 vert and 1 available
                # elif checkCellAboveBelow(currentCell, checkNum) == 2 and checkColumn(currentPos, currentCell, checkNum) == 0 and checkCellsCol(currentPos, currentCell, checkNum) == 0 and checkCellsCol(currentPos, currentCell, 0) == 1:
                elif twoUD1BlankInCol(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                # if 2 horizontal and 1 available
                # elif checkCellLeftRight(currentCell, checkNum) == 2 and checkRow(currentPos, currentCell, checkNum) == 0 and checkCellsRow(currentPos, currentCell, 0) == 1:
                elif twoLR1BlankInRow(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10
##

                # if 2 vert and 1-2 available
                # +1 horizontal and 1 available
                # even shorter
                elif shorter2LR1UDMult(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                elif shorter2LR1UDMultv2(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                elif twoUD1LRMultAvail(currentCell, currentPos, checkNum) == 'true' and checkCellsCol(currentPos, currentCell, 0) == 1:  # shorter replacement
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10
                    # end if 2 vert and 1-2 available
                    # +1 horizontal and 1 available

                # if 2 horizontal and 1-2 available
                # +1 vert and 1 available
                # even shorter # 2
                elif shorter2UD1LRMult(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                elif shorter2UD1LRMultv2(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                # elif checkCellsRow(currentPos, currentCell, 0) == 1:
                elif twoLR1UDMultAvail(currentCell, currentPos, checkNum) == 'true' and checkCellsRow(currentPos, currentCell, 0) == 1:
                    tmpCell = retSingleCell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    CellEdit(tmpCell, currentCell)
                    checkNum = 10

                elif countBlankSquares(retSingleCell(currentCell)) >= 2:
                    zeros = countBlankSquares(retSingleCell(currentCell))
                    tmpCell = retSingleCell(currentCell)
                    lstOfZeros = []
                    ink = 1
                    while ink <= 9:
                        if tmpCell[(ink - 1)] == '0':
                            lstOfZeros.append(ink)
                        ink += 1

                    ink = 0
                    zerRes = []
                    while ink < zeros:
                        if checkRow(lstOfZeros[ink], currentCell, checkNum) == 0 and checkColumn(lstOfZeros[ink], currentCell, checkNum) == 0:
                            zerRes.append('t')
                        else:
                            zerRes.append('f')
                        ink += 1

                    if zerRes.count('t') == 1 and checkRow(currentPos, currentCell, checkNum) == 0 and checkColumn(currentPos, currentCell, checkNum) == 0:
                        tmpCell = retSingleCell(currentCell)
                        tmpCell[(currentPos - 1)] = str(checkNum)
                        CellEdit(tmpCell, currentCell)
                        checkNum = 10

                # end if 2 horizontal and 1-2 available
                # +1 vert and 1 available

                checkNum += 1
        currentPos += 1
        # end while

    arr = [currentPos, currentCell]

    global stale
    stale += 1
    return arr  # end solve


# prints the sudoku grid
printFormat()

# example
# does cell 4 have a 2
# print (cellContains(SudLines[4], 2))


# print(countBlankSquares(SudLines[2]))

def testEdit(cell, cellNum, pos, num):
    print(cell)
    cell[(pos - 1)] = str(num)
    print(cell)
    SudLines[(cellNum - 1)] = cell
    printFormat()
    return

# prints the number of blank squares remaining
totalBlankSquares()

i = 1
current = [1, 1]  # current pos, current cell
# while there was a filled in number in the past 10000 position checks
while stale <= 10000 and solved == 'false':

    current = solve(current[0], current[1])
    i += 1

if stale >= 10001:
    print('10000 moves checked since last move. Giving up...')
