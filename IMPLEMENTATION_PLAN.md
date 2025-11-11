# Implementation Plan for Issue #21

## Issue: test packages does not work

## Plan

- [ ] **Update Action Version**: Modify the pipeline to use the latest version of `actions/upload-artifact` (e.g., `v5.0.0`). This change should be testable by running a pipeline with the updated action.
- [ ] **Verify Update**: Run the modified pipeline and verify that it completes successfully without errors related to the deprecated action version.
- [ ] **Documentation Review**: Check if any documentation needs to be updated to reflect the new action version. If necessary, update the relevant sections in the documentation.
- [ ] **Test Pipeline**: Create a separate test pipeline that specifically tests the `actions/upload-artifact` action with different versions to ensure compatibility and proper functionality.
- [ ] **Code Review**: Perform a code review of the changes made to ensure they meet the project's coding standards and best practices.
