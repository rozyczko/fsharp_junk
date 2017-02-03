let rec anotherInsertionSort lst = 
    List.foldBack(fun x ys ->  
                    match ys with
                    | [] -> [x]
                    | y::_ when x <= y -> x::ys 
                    | y::ys -> y::(anotherInsertionSort (x::ys))) lst [] 


