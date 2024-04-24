.globl main 
.equ STDOUT, 1
.equ STDIN, 0
.equ __NR_READ, 63
.equ __NR_WRITE, 64
.equ __NR_EXIT, 93

.text
main:
	# main() prolog
	addi sp, sp, -24
	sw ra, 20(sp)

	# main() body
	la a0, prompt
	call puts

	mv a0, sp
	call gets

	mv a0, sp
	call puts

	# main() epilog
	lw ra, 20(sp)
	addi sp, sp, 24
	ret

.space 12288

sekret_fn:
	addi sp, sp, -4
	sw ra, 0(sp)
	la a0, sekret_data
	call puts
	lw ra, 0(sp)
	addi sp, sp, 4
	ret

##############################################################
# Add your implementation of puts() and gets() below here
##############################################################

//-------------------------------------------------------------------------------------------------------------
getchar :
// prolog
# adjust sp for 1 item
addi sp, sp,-4
# zero - out the memory address that sp is pointing to
sw sp, 0(sp)

#body:
# Put STDIN code into a0
li a0, 0      #STDIN = 0
# Put sp into a1 // a place to store the read - in char
addi a1, sp, 0
# Put value 1 into a2 // read in one byte
li a2, 1
# Put NR_READ code into a7
li a7,63      #__NR_READ = 63
ecall

// epilog:
# load * sp into a0 // return ascii value
lbu a0, 0(sp)
# restore sp
addi sp, sp, 4
# return
ret

//-------------------------------------------------------------------------------------------------------------

//-------------------------------------------------------------------------------------------------------------
gets :
// prolog : a0 contains addr pointer

# make room for 3 items on the stack
addi sp,sp,-12
# save ra , a0 , and s0
sw ra, 8(sp)
sw a0, 4(sp)
sw s0, 0(sp)

// body
# move a0 into s0 // use s0 to increment the addr pointer
mv s0, a0

gets_loop:
# Call getchar
call getchar
// At this point , the read - in char put into a0

# If read - in char is negative , goto gets_error
#blt a0, zero, gets_error
bltz a0, gets_error

sb a0, 0(s0)

# Increment s0 by 1
addi s0, s0, 1 

#( ascii value 10)
li t1, 10
# goto gets_loop if read - in char is not newline ( ascii value 10)
bne a0, t1 , gets_loop

# end the input string with a terminating 0 byte
sb zero, 0(s0)

// Epilog ( was newline ) #save.4.2.7

# Restore stack items and sp // a0 now holds base addr of input string
lw ra, 8(sp)
lw a0, 4(sp)
lw s0, 0(sp)
addi sp, sp, 12

# Put s0 - a0 into a0 // return length of read - in string
sub a0, s0, a0

# return
ret

gets_error :
# Restore stack items and sp
lw ra, 8(sp)
lw a0, 4(sp)
lw s0, 0(sp)
addi sp, sp, 12

// a0 should hold current ( error ) ascii value
# retur
ret
//-------------------------------------------------------------------------------------------------------------




//-------------------------------------------------------------------------------------------------------------
putchar :
// prolog
# adjust sp for 1 item
addi sp, sp, -4
# store a0 into stack // save input char into memory
sw a0, 0(sp)

// body
# Put STDOUT code into a0
li a0,1   #STDOUT= 1
# Put sp into a1 // pointer to input char
addi a1, sp, 0
# Put value 1 into a2 // write 1 byte
li a2, 1
# Put NR_WRITE code into a7
li a7, 64      #__NR_WRITE= 64
ecall

// epilog
# load ( byte value ) of * sp back into a0
lw a0, 0(sp)
# restore sp
addi sp, sp, 4
# return
ret
//-------------------------------------------------------------------------------------------------------------


//-------------------------------------------------------------------------------------------------------------
puts :
// Prolog

# Make room for 1 item on the stack
addi sp, sp, -4
# save ra
sw ra, 0(sp)
// body

# move a0 into s0 // use s0 to increment the addr pointer
mv s0, a0

puts_loop :
# Put the ascii value that s0 is currently pointing to into a0
lb a0, 0(s0)


# set t1 register to ascii value 0
#li t1, 0 

# if ascii value is zero ( null char ) , goto to puts_exit
#beq a0, t1, puts_exit
beqz a0, puts_exit

# Call putchar
call putchar

# Increment string pointer s0
addi s0, s0, 1

# If a0 >= 0 , goto puts_loop
#bge a0, t1, puts_loop
bgez a0, puts_loop

// Error branch ( a0 < 0)
#blt a0,t1,Error
bltz a0,Error

Error:
# Put -1 into a0 // return -1
li a0, -1
# Restore stack items and sp
lw ra, 0(sp)
# return
ret

puts_exit :
# Put newline char into a0 ( value 10)
li a0, 10
# Call putchar
call putchar
# Put 0 into a0 // return 0
li a0, 0

// Epilog
# restore stack items and sp
lw ra, 0(sp)
addi sp, sp, 4
# return
ret
//-------------------------------------------------------------------------------------------------------------

##############################################################

.data
prompt:   .ascii  "input: "
prompt_end:

.word 0
sekret_data:
.word 0x73564753, 0x67384762, 0x79393256, 0x3D514762, 0x0000000A


//1234567890abcdefghijèþÿ¿
#XXXXXXXXXXXXXXXXXXXXXXXBBBB
# 0xBFFFFEE8

#B = 1011; unix code  = 1001 0000
#F = 1111 ; unix code = 1111 0000
#F = 1111 ; unix code = 1111 0000
#F = 1111 ; unix code = 1111 0000
#F = 1111 ; unix code = 1111 0000
#E = 1110 ; unix code = 1110 0000
#E = 1110 ; unix code = 1110 0000
#8 = 1000 ; unix code = 1000 0000  : na :

#:  °ððððàà€


