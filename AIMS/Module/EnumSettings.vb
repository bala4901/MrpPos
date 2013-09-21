Public Class EnumSettings

    Public Enum JobStatusEnum
        NA = 0 'Not Activated
        Q = 1 'Queue
        P = 2 'Processing
        C = 3 'Completed
        E = 4 'Error
    End Enum

    Public Enum JobTypeEnum
        SI = 0 'Store-in 
        FI = 1 'Fill-up
        SO = 2 'Store-out
        PI = 3 'Picking
        CL = 4 'Cycle-count by location
        CI = 5 'Cycle-count by item
    End Enum

    Public Enum BankNumberEnum
        Bank_01 = 1
        Bank_02 = 2
    End Enum

    Public Enum LocationViewGridSize
        Small = 25
        Medium = 35
        Large = 50
        Largest = 60
    End Enum

    Public Enum LocationSizeEnum
        Low = 1
        High = 2
    End Enum

    Public Enum LocationStatusEnum
        Empty = 1
        Occupied = 2
        Prohibited = 3
        Empty_Bin = 4
        Processing_Store_In = 5
        Processing_Store_Out = 6
        Processing_Cycle_Count = 7
        Unusable = 8
        [Error] = 9
    End Enum

    Public Enum MovementTypeEnum
        Inactive = 1
        Slow = 2
        Fast = 3
    End Enum

End Class
