import axios from "axios";
import { useEffect, useState } from "react";
import { Card, Button } from "react-bootstrap";
import './styles.css';
import { BsPencilSquare } from "react-icons/bs";
import { TiDelete } from "react-icons/ti";
import backgroundImage from "../assets/background.png";

interface Student {
  id: number;
  todotitle: string;
  todoabout: string;
}

function TodoCRUD() {
  const [id, setId] = useState<number | "">("");
  const [todotitle, setTodotitle] = useState("");
  const [todoabout, setTodoabout] = useState("");
  const [students, setStudents] = useState<Student[]>([]);

  useEffect(() => {
    Load();
  }, []);

  async function Load() {
    try {
      const result = await axios.get<Student[]>("http://localhost:5142/api/Todo/GetTodo");
      setStudents(result.data);
    } catch (err) {
      console.error(err);
    }
  }

  async function save(event: React.FormEvent) {
    event.preventDefault();
    try {
      await axios.post("http://localhost:5142/api/Todo/AddTodo", {
        todotitle,
        todoabout,
      });
      alert("Task Added Successfully");
      setId("");
      setTodotitle("");
      setTodoabout("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  async function editStudent(student: Student) {
    setTodotitle(student.todotitle);
    setTodoabout(student.todoabout);
    setId(student.id);
  }

  async function deleteStudent(id: number) {
    try {
      await axios.delete(`http://localhost:5142/api/Todo/DeleteTodo/${id}`);
      alert("Task deleted successfully");
      setId("");
      setTodotitle("");
      setTodoabout("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  async function update(event: React.FormEvent) {
    event.preventDefault();
    try {
      await axios.patch(`http://localhost:5142/api/Todo/UpdateTodo/${id}`, {
        id,
        todotitle,
        todoabout,
      });
      alert("Task Updated");
      setId("");
      setTodotitle("");
      setTodoabout("");
      Load();
    } catch (err) {
      alert(err);
    }
  }

  const getColor = (index: number)=> {
    const colors = ["#BA9B09", "#886902", "#261900"];
    return colors[index % colors.length];
  }

  const [placeholder, setPlaceholder] = useState("Title");


  return (
    <div style={{
      backgroundImage: `url(${backgroundImage})`,
      backgroundSize: '100% auto',
      backgroundRepeat: 'no-repeat',
      maxWidth: '100vw', 
      padding: '20px',
      boxSizing: 'border-box',
    }}>
      <h1>TaskMaster, Organize Your Day, Your Way!</h1>
      <div className="container mt-4">
        <form>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              id="id"
              hidden
              value={id}
              onChange={(event) => {
                setId(Number(event.target.value));
              }}
            />
           
            <input
              type="text"
              className="form-control"
              placeholder="Title"
              id="stname"
              value={todotitle}
              onChange={(event) => {
                setTodotitle(event.target.value);
              }}
            />
          </div>
          <div className="form-group">
            
            <input
              type="text"
              placeholder={placeholder}
              className="form-control"
              id="course"
              value={todoabout}
              onFocus={() => setPlaceholder("")}
              onBlur={() => setPlaceholder("Description")}
              onChange={(event) => {
                setTodoabout(event.target.value);
              }}
            />
          </div>
          <div>
            <button className="btn btn-primary mt-4" onClick={save}>
           
               Add Task
            </button>
            <button className="btn btn-warning mt-4" onClick={update}>
            
              Update Task
            </button>
          </div>
        </form>
      </div>
      <br />
      <br />
      <br />
      <br />
      <div className="container" style={{ display: 'flex', flexWrap: 'wrap' }}>
  {students.map((student, index) => (
    <div className="col-md-4" key={student.id} style={{ width: '28rem', margin: '10px', order: index % 3 }}>
      <Card className="mb-4" style={{ backgroundColor: getColor(index) }}>
        <Card.Body id="cardBody">
          <div>
            <Card.Title>{student.todotitle}</Card.Title>
            <Card.Text>{student.todoabout}</Card.Text>
          </div>
          <div style={{ marginLeft: 15 }}>
            <Button id="editbtn" variant="warning" onClick={() => editStudent(student)}>
              <BsPencilSquare />
            </Button>
            <Button id="deletebtn" variant="danger" onClick={() => deleteStudent(student.id)}>
              <TiDelete />
            </Button>
          </div>
        </Card.Body>
      </Card>
    </div>
  ))}
</div>

    </div>
  );
}

export default TodoCRUD;
