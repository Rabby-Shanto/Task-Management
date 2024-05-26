export interface TaskList {

    statusCode: string
    message: string
    data: Tasks[]
    totalItems: number
    pageSize: number
  }
  
  export interface Tasks {
    id: number
    title: string
    description: string
    dueDate: string
    status: string
  }

