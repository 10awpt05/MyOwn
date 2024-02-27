package org.example
fun main() {
    println("Enter a number: ")
    val userInput = readLine()?.toInt()

    if (userInput != null && userInput > 0) {
        // print("$userInput = ")

        var result = 1
        for (i in userInput downTo 1) {
            print(i)

            if (i > 1) {
                print("x")
            }

            result *= i
        }

        print(" = $result")
    } else {
        println("Please enter a positive integer.")
    }
}

