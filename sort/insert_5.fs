let insertionSort xs =
    let shiftInsert xs x =
        let rec shift xs acc isAdd =
            match xs, isAdd with
            | [], true -> acc
            | [], false -> x::acc
            | h::t, false -> 
                if h <= x then
                    shift t (h::acc) false
                else
                    shift t (h::x::acc) true
            |h::t,true -> 
                shift t (h::acc) true
        shift xs [] false
        |> List.rev
    List.fold shiftInsert [] xs


