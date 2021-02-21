import { gql } from "apollo-server";

export default gql`
  type Query {
    allPresentations: [Presentation]
    presentationById(id: ID): Presentation
  }
  type Presentation {
    id: ID!
    name: String!
  }
`;
