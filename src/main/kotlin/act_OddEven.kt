package org.example
var num: Int? = 0

fun main() {
    var b = 0
    println("Enter a number: ")
    num = readLine()?.toInt()
    if(num!! %2==0) {
        println("$num is even: \n"+ "even even for $num to 0:")
        for(i in num!! downTo 2) {
            if (i % 2 == 0) print(i)
        }
    }else if(num!! %2!=0){
        println("$num is odd: \n"+ "even odd for $num to 0:")
        for(i in num!! downTo 1) {
            if (i % 2 != 0) print(i)
        }
    }
}