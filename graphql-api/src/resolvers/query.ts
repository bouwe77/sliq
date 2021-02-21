const query = {
  allPresentations: (
    parent: any,
    args: any,
    { dataSources }: any,
    info: any
  ) => {
    return dataSources.Presentations.getPresentations();
  },
  presentationById: (
    parent: any,
    { id }: any,
    { dataSources }: any,
    info: any
  ) => {
    return dataSources.Presentations.getPresentationById(id);
  },
};

export default query;
