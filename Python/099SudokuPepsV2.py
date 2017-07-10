""" Sudoku Peps V2: The purpose of this program is to solve a
sudoku puzzle from a file while understanding the basics of python
and the Pep8 standards.
Written by Cameron Prince"""

#  import io
import os

path = os.path.join(os.getcwd(), 'SampleData', 'sudoku5.txt')

SUD_LINES = [line.rstrip('\n') for line in open(path)]
NUM_LIST = ['1', '2', '3', '4', '5', '6', '7', '8', '9']

CHAR_0 = list(SUD_LINES[0])
CHAR_1 = list(SUD_LINES[1])
CHAR_2 = list(SUD_LINES[2])
CHAR_3 = list(SUD_LINES[3])
CHAR_4 = list(SUD_LINES[4])
CHAR_5 = list(SUD_LINES[5])
CHAR_6 = list(SUD_LINES[6])
CHAR_7 = list(SUD_LINES[7])
CHAR_8 = list(SUD_LINES[8])

SOLVED = 'false'
STALE = 0  # used to put a limit on the amount of cell checks allowed


def update_chars(l):
    """ Update the characters for each 3x3 square """
    global CHAR_0
    CHAR_0 = list(l[0])
    global CHAR_1
    CHAR_1 = list(l[1])
    global CHAR_2
    CHAR_2 = list(l[2])
    global CHAR_3
    CHAR_3 = list(l[3])
    global CHAR_4
    CHAR_4 = list(l[4])
    global CHAR_5
    CHAR_5 = list(l[5])
    global CHAR_6
    CHAR_6 = list(l[6])
    global CHAR_7
    CHAR_7 = list(l[7])
    global CHAR_8
    CHAR_8 = list(l[8])
    return


def print_format():
    """ This function prints the updated puzzle in an easy to read format """
    update_chars(SUD_LINES)
    print '+-----------+'
    print '|' + CHAR_0[0] + CHAR_0[1] + CHAR_0[2] + '|' + CHAR_1[0] + CHAR_1[1] + CHAR_1[2] + '|' + CHAR_2[0] + CHAR_2[1] + CHAR_2[2] + '|'
    print '|' + CHAR_0[3] + CHAR_0[4] + CHAR_0[5] + '|' + CHAR_1[3] + CHAR_1[4] + CHAR_1[5] + '|' + CHAR_2[3] + CHAR_2[4] + CHAR_2[5] + '|'
    print '|' + CHAR_0[6] + CHAR_0[7] + CHAR_0[8] + '|' + CHAR_1[6] + CHAR_1[7] + CHAR_1[8] + '|' + CHAR_2[6] + CHAR_2[7] + CHAR_2[8] + '|'
    print '+---|---|---+'
    print '|' + CHAR_3[0] + CHAR_3[1] + CHAR_3[2] + '|' + CHAR_4[0] + CHAR_4[1] + CHAR_4[2] + '|' + CHAR_5[0] + CHAR_5[1] + CHAR_5[2] + '|'
    print '|' + CHAR_3[3] + CHAR_3[4] + CHAR_3[5] + '|' + CHAR_4[3] + CHAR_4[4] + CHAR_4[5] + '|' + CHAR_5[3] + CHAR_5[4] + CHAR_5[5] + '|'
    print '|' + CHAR_3[6] + CHAR_3[7] + CHAR_3[8] + '|' + CHAR_4[6] + CHAR_4[7] + CHAR_4[8] + '|' + CHAR_5[6] + CHAR_5[7] + CHAR_5[8] + '|'
    print '+---|---|---+'
    print '|' + CHAR_6[0] + CHAR_6[1] + CHAR_6[2] + '|' + CHAR_7[0] + CHAR_7[1] + CHAR_7[2] + '|' + CHAR_8[0] + CHAR_8[1] + CHAR_8[2] + '|'
    print '|' + CHAR_6[3] + CHAR_6[4] + CHAR_6[5] + '|' + CHAR_7[3] + CHAR_7[4] + CHAR_7[5] + '|' + CHAR_8[3] + CHAR_8[4] + CHAR_8[5] + '|'
    print '|' + CHAR_6[6] + CHAR_6[7] + CHAR_6[8] + '|' + CHAR_7[6] + CHAR_7[7] + CHAR_7[8] + '|' + CHAR_8[6] + CHAR_8[7] + CHAR_8[8] + '|'
    print '+-----------+'
    return


def return_single_cell(num):
    """ Return a single cell """
    update_chars(SUD_LINES)
    num = int(num)
    if num == 1:
        return CHAR_0
    elif num == 2:
        return CHAR_1
    elif num == 3:
        return CHAR_2
    elif num == 4:
        return CHAR_3
    elif num == 5:
        return CHAR_4
    elif num == 6:
        return CHAR_5
    elif num == 7:
        return CHAR_6
    elif num == 8:
        return CHAR_7
    elif num == 9:
        return CHAR_8
    else:
        return


def quick_delete(cell, n1, n2, n3):
    """ Delete the un-needed numbers (other 2 columns) for quick calculations """
    del cell[n1]
    del cell[n1]
    del cell[n2]
    del cell[n2]
    del cell[n3]
    del cell[n3]
    return cell


def quick_deleteV2(cell):  # for midd col
    """ Delete the un-needed numbers (other 2 columns) for quick calculations
    This one works for the middle column"""
    del cell[0]
    del cell[1]
    del cell[1]
    del cell[2]
    del cell[2]
    del cell[3]
    return cell


def quick_deleteV3(cell, n1, n2):  # for row
    """ Delete the un-needed numbers (other 2 rows) for quick calculations """
    del cell[n1]
    del cell[n1]
    del cell[n1]
    del cell[n2]
    del cell[n2]
    del cell[n2]
    return cell


def quick_column(cl1, currPos):
    """ Checks the position, and determines the best quick_delete to use (for column) """
    if currPos == 1 or currPos == 4 or currPos == 7:
        cl1 = quick_delete(cl1, 1, 2, 3)
        return cl1
    elif currPos == 2 or currPos == 5 or currPos == 8:
        cl1 = quick_deleteV2(cl1)
        return cl1
    elif currPos == 3 or currPos == 6 or currPos == 9:
        cl1 = quick_delete(cl1, 0, 1, 2)
        return cl1
    else:
        return 0


def return_number_at_position(cellNum, pos):
    """ Return the number for the given cell and position """
    cellNum = return_single_cell(cellNum)
    return cellNum[(int(pos) - 1)]


def cell_contains(cell, num):
    """ Determine if given cell contains the given number """
    if cell.count(str(num)) > 0:
        return 'true'
    else:
        return 'false'


def count_blank_squares(cell):
    """ Determine the number of blank spaces for a given cell """
    return cell.count('0')


def total_blank_squares():
    """ Counts the total blank squares. If it is 0, then marks the puzzle as solved. """
    count = 0
    ink = 1
    while ink <= 9:
        count += return_single_cell(ink).count('0')
        ink += 1
    print 'There are ' + str(count) + ' blank cells left'
    if count == 0:
        print 'Sudoku solved!'
        global SOLVED
        SOLVED = 'true'
        global STALE
        STALE = 0
    return


# override/update a cell
def cell_edit(cell, cellNum):
    """ Override or update a cell given the new cell data """
    global STALE
    STALE = 0
    global SUD_LINES
    SUD_LINES[(cellNum - 1)] = cell
    print_format()
    total_blank_squares()
    return


def check_cell_above_below(currentCell, num):
    """ check cell above and below for num """
    output = 0
    inx = currentCell + 3
    if inx > 9:
        inx = inx - 9
    tmpCell = return_single_cell(inx)
    output += tmpCell.count(str(num))
    inx = inx + 3
    if inx > 9:
        inx = inx - 9
    tmpCell = return_single_cell(inx)
    output += tmpCell.count(str(num))
    return output


def check_cell_left_right(currentCell, num):
    """ check cell left and right for num """
    count = 0
    #  if 1, 4, 7
    if currentCell == 1 or currentCell == 4 or currentCell == 7:
        count += return_single_cell((currentCell + 1)).count(str(num))
        count += return_single_cell((currentCell + 2)).count(str(num))

    #  if 2, 5, 8
    elif currentCell == 2 or currentCell == 5 or currentCell == 8:
        count += return_single_cell((currentCell - 1)).count(str(num))
        count += return_single_cell((currentCell + 1)).count(str(num))

    #  if 3, 6, 9
    elif currentCell == 3 or currentCell == 6 or currentCell == 9:
        count += return_single_cell((currentCell - 1)).count(str(num))
        count += return_single_cell((currentCell - 2)).count(str(num))
    return count


def check_column(currPos, currCell, num):
    """ check column for num """
    Count = 0
    c1 = ''
    c2 = ''
    c3 = ''

    def insider(cl1, cl2, cl3, count):
        if currPos == 1 or currPos == 4 or currPos == 7:
            cl1 = quick_delete(cl1, 1, 2, 3)
            cl2 = quick_delete(cl2, 1, 2, 3)
            cl3 = quick_delete(cl3, 1, 2, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 2 or currPos == 5 or currPos == 8:
            cl1 = quick_deleteV2(cl1)
            cl2 = quick_deleteV2(cl2)
            cl3 = quick_deleteV2(cl3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 3 or currPos == 6 or currPos == 9:
            cl1 = quick_delete(cl1, 0, 1, 2)
            cl2 = quick_delete(cl2, 0, 1, 2)
            cl3 = quick_delete(cl3, 0, 1, 2)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        else:
            return 0
        #  end insider

    if currCell == 1 or currCell == 4 or currCell == 7:
        c1 = return_single_cell(1)
        c2 = return_single_cell(4)
        c3 = return_single_cell(7)
        return insider(c1, c2, c3, Count)
    elif currCell == 2 or currCell == 5 or currCell == 8:
        c1 = return_single_cell(2)
        c2 = return_single_cell(5)
        c3 = return_single_cell(8)
        return insider(c1, c2, c3, Count)
    elif currCell == 3 or currCell == 6 or currCell == 9:
        c1 = return_single_cell(3)
        c2 = return_single_cell(6)
        c3 = return_single_cell(9)
        return insider(c1, c2, c3, Count)
    else:
        return 0
    #  end check_column


def check_cells_column(currPos, currCell, num):
    """ Check a cell's column for a number """

    cl = return_single_cell(currCell)
    Count = 0

    def insider(cl1, count):
        if currPos == 1 or currPos == 4 or currPos == 7:
            cl1 = quick_delete(cl1, 1, 2, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 2 or currPos == 5 or currPos == 8:
            cl1 = quick_deleteV2(cl1)
            count += cl1.count(str(num))
            return count
        elif currPos == 3 or currPos == 6 or currPos == 9:
            cl1 = quick_delete(cl1, 0, 1, 2)
            count += cl1.count(str(num))
            return count
        else:
            return 0

    return insider(cl, Count)


def check_row(currPos, currCell, num):
    """ check row for number """

    Count = 0
    c1 = ''
    c2 = ''
    c3 = ''

    def insider(cl1, cl2, cl3, count):
        if currPos == 1 or currPos == 2 or currPos == 3:
            cl1 = quick_deleteV3(cl1, 3, 3)
            cl2 = quick_deleteV3(cl2, 3, 3)
            cl3 = quick_deleteV3(cl3, 3, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 4 or currPos == 5 or currPos == 6:
            cl1 = quick_deleteV3(cl1, 0, 3)
            cl2 = quick_deleteV3(cl2, 0, 3)
            cl3 = quick_deleteV3(cl3, 0, 3)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        elif currPos == 7 or currPos == 8 or currPos == 9:
            cl1 = quick_deleteV3(cl1, 0, 0)
            cl2 = quick_deleteV3(cl2, 0, 0)
            cl3 = quick_deleteV3(cl3, 0, 0)
            count += cl1.count(str(num))
            count += cl2.count(str(num))
            count += cl3.count(str(num))
            return count
        else:
            return 0
        #  end insider

    if currCell == 1 or currCell == 2 or currCell == 3:
        c1 = return_single_cell(1)
        c2 = return_single_cell(2)
        c3 = return_single_cell(3)
        return insider(c1, c2, c3, Count)
    elif currCell == 4 or currCell == 5 or currCell == 6:
        c1 = return_single_cell(4)
        c2 = return_single_cell(5)
        c3 = return_single_cell(6)
        return insider(c1, c2, c3, Count)
    elif currCell == 7 or currCell == 8 or currCell == 9:
        c1 = return_single_cell(7)
        c2 = return_single_cell(8)
        c3 = return_single_cell(9)
        return insider(c1, c2, c3, Count)
    else:
        return 0

    return
    #  end check row


def check_cells_row(currPos, currCell, num):
    """ Check cell's row for a number """

    cl = return_single_cell(currCell)
    Count = 0

    def insider(cl1, count):
        if currPos == 1 or currPos == 2 or currPos == 3:
            cl1 = quick_deleteV3(cl1, 3, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 4 or currPos == 5 or currPos == 6:
            cl1 = quick_deleteV3(cl1, 0, 3)
            count += cl1.count(str(num))
            return count
        elif currPos == 7 or currPos == 8 or currPos == 9:
            cl1 = quick_deleteV3(cl1, 0, 0)
            count += cl1.count(str(num))
            return count
        else:
            return 0

    return insider(cl, Count)


def two_ud_two_lr_col_no_row_no(currentCell, currentPos, checkNum):
    """ Check to see if the above, below, left, and right cells
    have a number, but that number is not in the current row and column """
    outy = 'false'
    if check_cell_above_below(currentCell, checkNum) == 2:
        if check_cell_left_right(currentCell, checkNum) == 2:
            if check_column(currentPos, currentCell, checkNum) == 0:
                if check_row(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def two_ud_1_blank_in_column(currentCell, currentPos, checkNum):
    """ Check to see if the above/below cells contain a number, but that
    number is not in the current row or column, and there is one blank
    in the current cell's current column """
    outy = 'false'
    if check_cell_above_below(currentCell, checkNum) == 2:
        if check_column(currentPos, currentCell, checkNum) == 0:
            if check_cells_column(currentPos, currentCell, checkNum) == 0:
                if check_cells_column(currentPos, currentCell, 0) == 1:
                    outy = 'true'
    return outy


def two_lr_1_blank_in_row(currentCell, currentPos, checkNum):
    """ Check to see if the left/right cells contain a number, but that
    number is not in the current row or column, and there is one blank
    in the current cell's current row """
    outy = 'false'
    if check_cell_left_right(currentCell, checkNum) == 2:
        if check_row(currentPos, currentCell, checkNum) == 0:
            if check_cells_row(currentPos, currentCell, 0) == 1:
                outy = 'true'
    return outy


def two_ud_1_lr_mult_available(currentCell, currentPos, checkNum):
    """ Check to see if the above and below cells have a number,
    but only 1 of the left and right cells have that number
    and that number is not in the current row and column """
    outy = 'false'
    if check_cell_above_below(currentCell, checkNum) == 2:
        if check_cell_left_right(currentCell, checkNum) == 1:
            if check_column(currentPos, currentCell, checkNum) == 0:
                if check_row(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def two_lr_1_ud_mult_available(currentCell, currentPos, checkNum):
    """ Check to see if the left and right cells have a number,
    but only 1 of the above and below cells have that number
    and that number is not in the current row and column """
    outy = 'false'
    if check_cell_left_right(currentCell, checkNum) == 2:
        if check_cell_above_below(currentCell, checkNum) == 1:
            if check_row(currentPos, currentCell, checkNum) == 0:
                if check_column(currentPos, currentCell, checkNum) == 0:
                    outy = 'true'
    return outy


def shorter_2lr_1ud_mult(currentCell, currentPos, checkNum):
    outy = 'false'
    if two_ud_1_lr_mult_available(currentCell, currentPos, checkNum) == 'true':
        if check_cells_column(currentPos, currentCell, 0) == 2:
            tmpCk = currentPos + 3
            if tmpCk > 9:
                tmpCk -= 9
            if return_number_at_position(currentCell, tmpCk) == '0':
                if check_row(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter_2lr_1ud_mult_v2(currentCell, currentPos, checkNum):
    outy = 'false'
    if two_ud_1_lr_mult_available(currentCell, currentPos, checkNum) == 'true':
        if check_cells_column(currentPos, currentCell, 0) == 2:
            tmpCk = currentPos + 6
            if tmpCk > 9:
                tmpCk -= 9
            if return_number_at_position(currentCell, tmpCk) == '0':
                if check_row(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter_2ud_1lr_mult(currentCell, currentPos, checkNum):
    outy = 'false'
    if two_lr_1_ud_mult_available(currentCell, currentPos, checkNum) == 'true':
        if check_cells_row(currentPos, currentCell, 0) == 2:
            tmpCk = 1

            if currentPos == 1 or currentPos == 4 or currentPos == 7:
                tmpCk = currentPos + 1
            elif currentPos == 2 or currentPos == 5 or currentPos == 8:
                tmpCk = currentPos + 1
            elif currentPos == 3 or currentPos == 6 or currentPos == 9:
                tmpCk = currentPos - 2
            if return_number_at_position(currentCell, tmpCk) == '0':
                if check_column(tmpCk, currentCell, checkNum) == 1:
                    outy = 'true'
    return outy


def shorter_2ud_1lr_mult_v2(currentCell, currentPos, checkNum):
    outy = 'false'
    if two_lr_1_ud_mult_available(currentCell, currentPos, checkNum) == 'true':
        if check_cells_row(currentPos, currentCell, 0) == 2:
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

            if return_number_at_position(currentCell, tmpCk) == '0':
                if check_column(tmpCk, currentCell, checkNum) == 1:
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
    if cell_contains(return_single_cell(currentCell), 0) == 'false':
        currentCell += 1
        currentPos = 1

    #  if cell is only missing 1 number
    elif count_blank_squares(return_single_cell(currentCell)) == 1:
        tmpCell = return_single_cell(currentCell)
        tmpNmList = ['1', '2', '3', '4', '5', '6', '7', '8', '9']
        ink = 1
        while cell_contains(tmpCell, 0) == 'true':
            if len(tmpNmList) > 1 and ink <= 9:
                if cell_contains(tmpCell, ink) == 'true':
                    del tmpNmList[tmpNmList.index(str(ink))]
                ink += 1
            else:
                i = tmpCell.index('0')
                tmpCell[i] = tmpNmList[0]
                cell_edit(tmpCell, currentCell)
                tmpNmList = ['1', '2', '3', '4', '5', '6', '7', '8', '9']
                ink = 1
        done = 1
    #  end if cell is only missing 1 number

    #  more than 1 missing number --v

    #  if current num is not missing
    elif return_number_at_position(currentCell, currentPos) != '0':
        currentPos += 1

    #  current number in current cell is 0
    else:

        while checkNum <= 9:

            if cell_contains(return_single_cell(currentCell), checkNum) == 'true':
                checkNum += 1
            else:

                #  if 2 vert, 2 horizontal, and 1 available
                #  if check_cell_above_below(currentCell, checkNum) == 2 and check_cell_left_right(currentCell, checkNum) == 2 and check_column(currentPos, currentCell, checkNum) == 0 and check_row(currentPos, currentCell, checkNum) == 0:
                if two_ud_two_lr_col_no_row_no(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10
##
                # if 2 vert and 1 available
                # elif check_cell_above_below(currentCell, checkNum) == 2 and check_column(currentPos, currentCell, checkNum) == 0 and check_cells_column(currentPos, currentCell, checkNum) == 0 and check_cells_column(currentPos, currentCell, 0) == 1:
                elif two_ud_1_blank_in_column(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                # if 2 horizontal and 1 available
                # elif check_cell_left_right(currentCell, checkNum) == 2 and check_row(currentPos, currentCell, checkNum) == 0 and check_cells_row(currentPos, currentCell, 0) == 1:
                elif two_lr_1_blank_in_row(currentCell, currentPos, checkNum) == 'true':  # shorter replacement
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10
##

                # if 2 vert and 1-2 available
                # +1 horizontal and 1 available
                # even shorter
                elif shorter_2lr_1ud_mult(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                elif shorter_2lr_1ud_mult_v2(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                elif two_ud_1_lr_mult_available(currentCell, currentPos, checkNum) == 'true' and check_cells_column(currentPos, currentCell, 0) == 1:  # shorter replacement
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10
                    # end if 2 vert and 1-2 available
                    # +1 horizontal and 1 available

                # if 2 horizontal and 1-2 available
                # +1 vert and 1 available
                # even shorter # 2
                elif shorter_2ud_1lr_mult(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                elif shorter_2ud_1lr_mult_v2(currentCell, currentPos, checkNum) == 'true':
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                # elif check_cells_row(currentPos, currentCell, 0) == 1:
                elif two_lr_1_ud_mult_available(currentCell, currentPos, checkNum) == 'true' and check_cells_row(currentPos, currentCell, 0) == 1:
                    tmpCell = return_single_cell(currentCell)
                    tmpCell[(currentPos - 1)] = str(checkNum)
                    cell_edit(tmpCell, currentCell)
                    checkNum = 10

                elif count_blank_squares(return_single_cell(currentCell)) >= 2:
                    zeros = count_blank_squares(return_single_cell(currentCell))
                    tmpCell = return_single_cell(currentCell)
                    lstOfZeros = []
                    ink = 1
                    while ink <= 9:
                        if tmpCell[(ink - 1)] == '0':
                            lstOfZeros.append(ink)
                        ink += 1

                    ink = 0
                    zerRes = []
                    while ink < zeros:
                        if check_row(lstOfZeros[ink], currentCell, checkNum) == 0 and check_column(lstOfZeros[ink], currentCell, checkNum) == 0:
                            zerRes.append('t')
                        else:
                            zerRes.append('f')
                        ink += 1

                    if zerRes.count('t') == 1 and check_row(currentPos, currentCell, checkNum) == 0 and check_column(currentPos, currentCell, checkNum) == 0:
                        tmpCell = return_single_cell(currentCell)
                        tmpCell[(currentPos - 1)] = str(checkNum)
                        cell_edit(tmpCell, currentCell)
                        checkNum = 10

                # end if 2 horizontal and 1-2 available
                # +1 vert and 1 available

                checkNum += 1
        currentPos += 1
        # end while

    arr = [currentPos, currentCell]

    global STALE
    STALE += 1
    return arr  # end solve


# prints the sudoku grid
print_format()

# prints the number of blank squares remaining
total_blank_squares()

i = 1
current = [1, 1]  # current pos, current cell
# while there was a filled in number in the past 10000 position checks
while STALE <= 10000 and SOLVED == 'false':

    current = solve(current[0], current[1])
    i += 1

if STALE >= 10001:
    print '10000 moves checked since last move. Giving up...'
