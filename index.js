const express = require("express");
const cors = require("cors");
const fs = require("fs");

const app = express();
const PORT = process.env.PORT || 3000;
const DATA_FILE = "./data.json";

app.use(cors());
app.use(express.json());

// Lexo të dhënat nga file
function readData() {
  const raw = fs.readFileSync(DATA_FILE, "utf-8");
  return JSON.parse(raw);
}

// Shkruaj të dhënat në file
function writeData(data) {
  fs.writeFileSync(DATA_FILE, JSON.stringify(data, null, 2));
}

// GET /api/sweets - merr të gjitha
app.get("/api/sweets", (req, res) => {
  const data = readData();
  res.json(data);
});

// GET /api/sweets/:id - merr një
app.get("/api/sweets/:id", (req, res) => {
  const data = readData();
  const sweet = data.find(s => s.id === parseInt(req.params.id));
  if (!sweet) return res.status(404).json({ message: "Nuk u gjet" });
  res.json(sweet);
});

// POST /api/sweets - shto të re
app.post("/api/sweets", (req, res) => {
  const data = readData();
  const newSweet = {
    id: data.length > 0 ? Math.max(...data.map(s => s.id)) + 1 : 1,
    name: req.body.name,
    category: req.body.category,
    price: req.body.price,
    stock: req.body.stock,
    description: req.body.description
  };
  data.push(newSweet);
  writeData(data);
  res.status(201).json(newSweet);
});

// PUT /api/sweets/:id - ndrysho
app.put("/api/sweets/:id", (req, res) => {
  const data = readData();
  const index = data.findIndex(s => s.id === parseInt(req.params.id));
  if (index === -1) return res.status(404).json({ message: "Nuk u gjet" });
  data[index] = { id: parseInt(req.params.id), ...req.body };
  writeData(data);
  res.json(data[index]);
});

// DELETE /api/sweets/:id - fshij
app.delete("/api/sweets/:id", (req, res) => {
  let data = readData();
  const index = data.findIndex(s => s.id === parseInt(req.params.id));
  if (index === -1) return res.status(404).json({ message: "Nuk u gjet" });
  data.splice(index, 1);
  writeData(data);
  res.json({ message: "U fshi me sukses" });
});

app.listen(PORT, () => {
  console.log(`API po ekzekutohet në portin ${PORT}`);
});
