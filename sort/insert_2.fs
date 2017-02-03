let rec insert x = function
  | [] -> [x]
  | y::ys -> if x<=y then x::y::ys
             else y::(insert x ys)

and insertionSort = function
  | [] -> []
  | x::xs -> insert x (insertionSort xs)

let myLst = [8;3;3;5;-6;0;1;4;-3;2]
let result = myLst |> insertionSort 


