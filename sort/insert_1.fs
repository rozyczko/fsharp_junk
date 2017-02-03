let insert x lst =
  let rec insertCont x cont = function
    | [] -> cont ([x])
    | h::t as l -> if x<=h then cont(x::l) 
                   else insertCont x (fun accLst -> cont(h::accLst)) t
  insertCont x (fun x -> x) lst

// Sorting via insertion
let insertionSort l =
  let rec insertionSortAcc acc = function
    | [] -> acc
    | h::t -> insertionSortAcc (insert h acc) t
  insertionSortAcc [] l

let lst = [24;33;17;-5;-16;0;1;4;-3;2;8;-19]

let res = insertionSort lst

