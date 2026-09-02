# WimabEvent — Milestone 3 Progress Record

**Milestone:** 3 — Invitations & RSVP  
**Status:** PLANNED  
**Progress Recorded:** 2 September 2026  
**Project:** WimabEvent  
**Developer:** Wisani Mabunda

---

## 1. Milestone Purpose

Milestone 3 introduces the invitation and RSVP workflow for WimabEvent.

The objective is to allow authenticated event hosts to invite guests to their events through secure invitation links, while allowing invited guests to respond without creating a WimabEvent account.

The milestone will establish the foundation for guest attendance management and the later QR-based event check-in system.

---

## 2. Milestone Scope

Milestone 3 will introduce the following functionality:

- Host-controlled event invitations.
- Secure invitation tokens.
- Invitation management for event hosts.
- Guest invitation links.
- Public guest RSVP without requiring a guest account.
- Accept and decline RSVP responses.
- Plus-one handling.
- Dietary requirement collection.
- RSVP deadline enforcement.
- Invitation status tracking.
- Preparation for QR-based event tickets.
- Preparation for event check-in.

---

## 3. Invitation Backend Foundation

The invitation backend will be secured using the authenticated event owner.

The system will:

- Allow authenticated hosts to create invitations only for their own events.
- Prevent users from creating invitations for another user's event.
- Allow hosts to view invitations belonging to their own events.
- Allow hosts to delete invitations belonging to their own events.
- Use a secure, non-guessable invitation token.
- Avoid trusting client-supplied ownership information.
- Ensure invitation access is controlled server-side.

The existing Invitation model contains:

- EventId
- GuestName
- GuestEmail
- GuestPhoneNumber
- InviteGuid
- IsAccepted
- BringingPlusOne
- IsAttended

The existing model will be reviewed and extended only where required by the Milestone 3 requirements.

---

## 4. Host Invitation Management

Authenticated event hosts will be able to manage invitations associated with their events.

The planned host functionality includes:

- Create an invitation.
- View invitations for an event.
- View invitation status.
- Delete an invitation.
- Generate or retrieve the guest invitation link.
- Copy the invitation link.
- Prepare the invitation for sharing through external communication platforms.

The host must only be able to manage invitations belonging to events they own.

---

## 5. Public Guest Invitation

Each invitation will contain a secure unique token.

The token will be used to access the guest invitation without requiring the guest to create an account.

The invitation page will display relevant event information such as:

- Event title.
- Event date.
- Event location.
- Guest name.
- RSVP deadline when configured.

The invitation token must not expose sensitive internal database information unnecessarily.

---

## 6. RSVP Workflow

The guest RSVP workflow will support:

### Accept

A guest can accept an invitation.

When accepting, the guest will provide the information required by the event.

This will include:

- Attendance confirmation.
- Plus-one selection where permitted.
- Dietary requirements.

### Decline

A guest can decline an invitation.

The system will record the RSVP response and update the invitation status.

### RSVP Status

The system will distinguish between invitation states such as:

- Pending
- Accepted
- Declined

The final implementation will ensure the status is derived from reliable backend data rather than client-controlled values.

---

## 7. Dietary Requirements

Dietary requirements will be collected as part of the acceptance process.

When a guest accepts an invitation, the RSVP form will require the guest to provide dietary information.

The system will support guests who have no dietary requirements by allowing an appropriate response such as:

`None`

The backend will validate the required field rather than relying only on frontend validation.

---

## 8. Plus-One Handling

The RSVP workflow will support plus-one responses.

A guest will be able to indicate whether they are bringing a plus-one.

Where a plus-one is selected, the system will collect the plus-one information required by the application.

The final data model and validation rules will be confirmed during implementation.

---

## 9. RSVP Deadline

The event host will eventually be able to define an RSVP deadline.

The deadline must be enforced by the backend.

After the RSVP deadline has passed:

- New RSVP responses must not be accepted.
- Existing invitation information may still be viewed where appropriate.
- The guest should receive a clear indication that RSVP submissions are closed.

The deadline must not depend solely on JavaScript or browser-side validation.

---

## 10. Invitation Security

Security is a major requirement of this milestone.

The implementation will ensure:

- Invitation tokens are unique.
- Invitation tokens are difficult to guess.
- Guests cannot access another invitation by changing an ordinary numeric ID.
- Hosts cannot manage invitations belonging to another host.
- Event ownership is checked server-side.
- RSVP submissions are validated server-side.
- Expired invitations/deadlines are enforced server-side.
- Client-supplied ownership information is not trusted.

---

## 11. QR Ticket Preparation

Milestone 3 will prepare the invitation system for the later QR ticket functionality.

An accepted invitation will eventually receive a unique ticket identifier that can be represented as a QR code.

The QR functionality itself may be implemented as part of the later event check-in milestone if it is more appropriate to separate the concerns.

The important requirement for Milestone 3 is that the invitation/RSVP data model supports secure ticket identification.

---

## 12. Frontend Integration

The invitation functionality will be integrated into the existing WimabEvent frontend.

The host interface should follow the existing application design system.

The invitation interface should remain consistent with:

- Dashboard styling.
- Events page styling.
- Navy colour system.
- Gold accent system.
- Existing card design.
- Existing button interaction patterns.
- Responsive layout.

The public guest RSVP interface should have a professional and clear presentation suitable for guests who may access it from a mobile device.

---

## 13. API Endpoints

The final API structure will be confirmed during implementation.

The planned endpoint responsibilities include:

### Host Invitation Management

- Create invitation.
- List invitations for an owned event.
- Retrieve an invitation where authorized.
- Delete an invitation.

### Public Invitation

- Retrieve invitation using secure token.
- Submit RSVP using secure token.

### Authentication

Host invitation management endpoints will require ASP.NET Core Identity authentication.

Public guest invitation and RSVP endpoints will use the invitation token rather than requiring a guest account.

---

## 14. Data Model Considerations

The existing Invitation model will be reviewed before implementation.

The implementation will determine whether additional fields are required for:

- RSVP status.
- RSVP date.
- Dietary requirements.
- Plus-one information.
- RSVP deadline.
- Ticket identifier.
- Check-in preparation.

Existing Guest functionality will also be reviewed to determine whether invitation and RSVP data should remain separate or whether relationships should be strengthened.

No unnecessary duplication of guest information should be introduced.

---

## 15. Testing Plan

Milestone 3 testing will include:

### Invitation Creation

- [ ] Authenticated host can create an invitation.
- [ ] Invitation is linked to the correct event.
- [ ] Host cannot create an invitation for another user's event.
- [ ] Invitation receives a unique secure token.

### Invitation Management

- [ ] Host can view invitations for their own event.
- [ ] Host cannot view another user's invitations.
- [ ] Host can delete their own invitation.
- [ ] Host cannot delete another user's invitation.

### Public Invitation

- [ ] Valid invitation token opens the invitation.
- [ ] Invalid invitation token is rejected.
- [ ] Modified token cannot access another invitation.
- [ ] Guest does not need an account to view the invitation.

### RSVP

- [ ] Guest can accept an invitation.
- [ ] Guest can decline an invitation.
- [ ] RSVP status is stored correctly.
- [ ] RSVP date is recorded.
- [ ] Plus-one response is stored correctly.
- [ ] Dietary requirements are collected.
- [ ] Required RSVP information is validated server-side.

### Deadline

- [ ] RSVP deadline can be configured.
- [ ] RSVP is accepted before the deadline.
- [ ] RSVP is rejected after the deadline.
- [ ] Backend enforcement works even when frontend validation is bypassed.

### Security

- [ ] Authenticated host ownership is enforced server-side.
- [ ] Client-supplied UserId values are not trusted.
- [ ] Invitation tokens are non-guessable.
- [ ] Unauthorized invitation management is rejected.
- [ ] Invalid or expired invitation access is handled safely.

---

## 16. Development Journal

### 2 September 2026

Milestone 2 documentation was completed and formally marked COMPLETE.

The next development milestone was defined as Invitations & RSVP.

Before implementation, the invitation and RSVP requirements were documented to establish the intended backend security model, public guest workflow, RSVP requirements and preparation for future QR-based event check-in.

No Invitation & RSVP implementation has been completed yet.

---

## 17. Milestone Completion Criteria

Milestone 3 will be considered complete when:

- [ ] Secure invitation creation is implemented.
- [ ] Host ownership checks are enforced.
- [ ] Invitation management is implemented.
- [ ] Secure invitation links are implemented.
- [ ] Public guest invitation access is implemented.
- [ ] Guest RSVP is implemented.
- [ ] Accept and decline responses are implemented.
- [ ] Plus-one handling is implemented.
- [ ] Dietary requirements are collected and validated.
- [ ] RSVP deadlines are enforced by the backend.
- [ ] Invitation status is correctly tracked.
- [ ] Invitation security has been tested.
- [ ] RSVP security has been tested.
- [ ] Frontend invitation management is integrated.
- [ ] Public RSVP interface is integrated.
- [ ] Application builds successfully.
- [ ] Milestone changes are committed and pushed to GitHub.

---

## 18. Current Checkpoint

**Milestone 1:** COMPLETE  
Gift Registry & Catalogue functionality completed, tested, committed and pushed.

**Milestone 2:** COMPLETE  
Authentication & Frontend Integration completed, tested, committed and pushed.

**Milestone 3:** PLANNED  
Invitations & RSVP documentation completed. Implementation has not yet started.

**Next development step:** Review the existing Invitation, Guest and Event models/controllers and implement the secure invitation backend foundation.
