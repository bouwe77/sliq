import { DataSource } from "apollo-datasource";

const presentations = [
  { id: "1", name: "React" },
  { id: "2", name: "GraphQL" },
  { id: "3", name: "Azure" },
];

class Presentations extends DataSource {
  constructor() {
    super();
  }

  initialize(config: any) {}

  getPresentations() {
    return presentations;
  }

  getPresentationById(id: any) {
    return presentations.find((p) => p.id === id);
  }
}

export default Presentations;
