import io

# Cameron Prince
# original: 1/8/13
# modified: 1/10/13
# Purpose:Create a tic-tac-toe game (207)
# Tic-Tac-toe

X = 'X' # defining constraints
O = 'O'
EMPTY = ' '
TIE = 'T'
NO_ONE = 'N'

# void instructions() //defining functions
# char askYesNo(string question)
# int askNumber(string question, int high, int low = 0)
# char humanPiece()
# char opponent(char piece)
# void displayBoard(const vector<char>& board)
# bool isLegal(const vector<char>& board, int move)
# int humanMove(const vector<char>& board, char human)
# int computerMove(vector<char> board, char computer)
# void announceWinner(char winner, char computer, char human)
# char winner(const vector<char>& board)


def instructions():
        # tells the human player the instructions
    print('Welcome to Tic-Tac-Toe.')

    print('Make your move known by entering a number, 0 - 8. The number')
    print('corresponds to the desired board position, as illustrated:\n')

    print('    0 | 1 | 2')
    print('    ---------')
    print('    3 | 4 | 5')
    print('    ---------')
    print('    6 | 7 | 8\n')
    print('The game is about to begin.\n\n')
    return

def askYesNo(question):
    # asks human player y/n then collects the response
    response = ''
    while (response != 'y' and response != 'n'):
        print(question + ' (y/n): ')
        response = input()
    return response


def askNumber(question, high, low):
    # asks the player a question, then the player gives coordinates of their move
    number = -1
    while (number > high or number < low):
        print(question + ' (' + str(low) + ' - ' + str(high) + '):')
        number = int(input())
    return number


def humanPiece():
    # asks if the wants to go first, if y then they go first, if n, they do not
    go_first = askYesNo('Do you require the first move?')
    if(go_first == 'y'):
        print('\nTake the first move.\n')
        return X
    else:
        print('\n... I will go first.\n')
        return O


def opponent(piece):
    # if the player is first and places an X, then the computer places an O
    # if nothing is placed then the computer places a X
    if(piece == X):
        return O
    else:
        return X


def displayBoard(board):
    # the board
    print('\n\t' + board[0] + ' | ' + board[1] + ' | ' + board[2])
    print('\t' + '--------')
    print('\t' + board[3] + ' | ' + board[4] + ' | ' + board[5])
    print('\t' + '--------')
    print('\t' + board[6] + ' | ' + board[7] + ' | ' + board[8])
    print('\n')
    return


def winner(board):
    # a list of all possible winning rows
    WINNING_ROWS =[ [0, 1, 2],
                       [3, 4, 5],
                       [6, 7, 8],
                       [0, 3, 6],
                       [1, 4, 7],
                       [2, 5, 8],
                       [0, 4, 8],
                       [2, 4, 6] ]  #[8][3]

    TOTAL_ROWS = 8

    # if any winning row has 3 values that are the same, but not empty, then there is a winner
    row = 0
    while row < TOTAL_ROWS:

        if( (board[WINNING_ROWS[row][0]] != EMPTY) and (board[WINNING_ROWS[row][0]] == board[WINNING_ROWS[row][1]]) and (board[WINNING_ROWS[row][1]] == board[WINNING_ROWS[row][2]]) ):
            return board[WINNING_ROWS[row][0]]
        row += 1

    # if there are no empty squares and no one has won, then there is a tie
    if board.count(EMPTY) == 0:  #(count(board.begin(), board.end(), EMPTY) == 0):
        return TIE

    # if nobody has won and it is not a tie, then the game is not over
    return NO_ONE


def isLegal(move, board):
    # if the spot is empty, then it is a legal move
    return (board[move] == EMPTY)


def humanMove(board, human):
    # asks where the human player will move
    # if the move is illegal, then it tells the human player
    move = askNumber('Where will you move?', (len(board) - 1), 0)  # board.size()
    while (isLegal(move, board) == False):
        print('\nThat square is already occupied.\n')
        move = askNumber("Where will you move?", (len(board) - 1), 0)  # board.size()
    print('Ok...\n')
    return move

def computerMove(board, computer):
    move = 0
    found = False

    # if the computer can win on its next move, it will do that move
    while (found == False and move < len(board)):  # board.size()
        if(isLegal(move, board)):
            board[move] = computer
            found = winner(board) == computer
            board[move] = EMPTY

        if(found == False):
            move += 1

    # if the human can win on the next move, then the computer will make that move
    # to block the human from winning
    if(found == False):
        move = 0
        human = opponent(computer)

        while (found == False and move < len(board)):  # board.size()
            if(isLegal(move, board)):
                board[move] = human
                found = winner(board) == human
                board[move] = EMPTY

            if (found == False):
                move += 1


    # if the computer cannot win/block the human on the next move then it will
    # take the next best open square

    if found == False:
        move = 0
        i = 0
        BEST_MOVES = [4, 0, 2, 6, 8, 1, 3, 5, 7]
        # pick the best open square
        while (found == False and i < len(board)):  # board.size
            move = BEST_MOVES[i]
            if (isLegal(move, board)):
                found = True
            i += 1

    print('I shall take square number ' + str(move) + '\n')
    return move


def announceWinner(winner, computer, human):  # announces the winner
    #if the computer wins
    if(winner == computer):
        print(winner + '`s won!\n')
        print('You lost.\n')
    # if the human wins
    elif (winner == human):
        print(winner + '`s won!\n')
        print('Congratulations , you won.\n')
    # if its a tie
    else:
        print('It`s a tie\n')
    return




move = 0  # initializes move
NUM_SQUARES = 9
board = [EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY]  # (NUM_SQUARES, EMPTY)

instructions() # calls instructions, and makes player 1 'X'
human = humanPiece()
computer = opponent(human)
turn = X
displayBoard(board)

while (winner(board) == NO_ONE): # if no one has one and the game is not over, then it is the next player's turn
    if (turn == human):
        move = humanMove(board, human)
        board[move] = human
        turn = computer
    else:
        move = computerMove(board, computer)
        board[move] = computer
        displayBoard(board)
        turn = opponent(turn)
    # calls announceWinner where it will announce the winner
announceWinner(winner(board), computer, human)
