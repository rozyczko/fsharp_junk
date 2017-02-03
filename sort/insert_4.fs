let rec insert i = function
  | h::t -> min h i::(insert (max h i) t)
  | _ -> [i]

let insertionSort l = List.foldBack insert l []


