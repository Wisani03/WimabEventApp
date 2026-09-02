# WimabEvent — Milestone 2 Completion Record

**Milestone:** 2 — Authentication & Frontend Integration  
**Status:** COMPLETE  
**Progress Recorded:** 31 August – 1 September 2026  
**Project:** WimabEvent  
**Developer:** Wisani Mabunda

---

## 1. Milestone Purpose

Milestone 2 focused on connecting the WimabEvent frontend to the application's real authentication system and replacing presentation/mock data with real backend data.

The milestone built on the existing ASP.NET Core Identity authentication system, event management functionality, guest management, invitations and gift registry/catalogue functionality.

---

## 2. Completed Progress

### 2.1 Authentication

The login endpoint was updated to use ASP.NET Core Identity's PasswordSignInAsync functionality.

The authentication flow now:

- Validates the supplied email and password.
- Establishes an authenticated Identity session.
- Creates an ASP.NET Core Identity authentication cookie.
- Enables lockout-on-failure.
- Returns an appropriate response when an account is temporarily locked.
- Returns Unauthorized when credentials are invalid.

### 2.2 Registration Testing

A real test account was successfully registered through the authentication API.

The test account was used to verify the complete authentication flow, including registration, login, authenticated requests and logout.

Credentials are intentionally not stored in project documentation.

### 2.3 Login Testing

The test account was successfully authenticated through:

`POST /api/auth/login`

The endpoint returned HTTP 200 with a successful login response.

The authentication response issued an ASP.NET Core Identity authentication cookie, confirming that the server-side Identity session was being established.

Invalid credentials were confirmed to return HTTP 401 Unauthorized.

### 2.4 Logout Testing

Logout was integrated with the server-side Identity authentication system.

The frontend logout action calls:

`POST /api/auth/logout`

After logout, the authenticated session was invalidated.

A subsequent request to:

`GET /api/auth/me`

returned HTTP 401 Unauthorized, confirming that the authenticated session had ended successfully.

### 2.5 Protected Frontend Testing

The dashboard now verifies the authenticated Identity session through:

`GET /api/auth/me`

Unauthenticated users are redirected to the public landing page.

This prevents the dashboard from being treated as an authenticated application area when no valid server-side Identity session exists.

### 2.6 Event Ownership Security

Event management was updated so that event ownership is determined by the authenticated Identity user.

The Events API now:

- Retrieves events belonging to the authenticated user.
- Retrieves individual events only when they belong to the authenticated user.
- Assigns the authenticated user's Identity ID when creating an event.
- Prevents the client from supplying an arbitrary UserId during event creation.
- Allows deletion only when the event belongs to the authenticated user.

This establishes user-specific access control for event data.

### 2.7 Event Creation Testing

Event creation was successfully tested through the authenticated frontend.

A test event was successfully created and persisted in the database.

The event appeared on the Events page after creation, confirming that the frontend and backend event-management flow was working with real database data.

### 2.8 Dashboard Backend Integration

A protected dashboard API was introduced:

`GET /api/dashboard`

The endpoint uses the authenticated Identity user to retrieve user-specific dashboard information.

The dashboard now provides database-driven values for:

- Total events
- Total guests
- Total invitations
- Total wishlist items
- Recent events
- Recent invitations

### 2.9 Dashboard Frontend Integration

The dashboard frontend was connected to the real dashboard API.

The following statistics are now populated from backend data:

- Event count
- Guest count
- Invitation count
- Wishlist count

Hardcoded dashboard event and invitation data was removed.

Recent events and recent invitations are rendered dynamically from the API response.

### 2.10 Dashboard User-Specific Data

The dashboard now retrieves data belonging to the authenticated user.

Recent events are restricted to the user's own events.

Invitation information is calculated from invitations belonging to the user's events.

This prevents the dashboard from displaying unrelated users' event information.

### 2.11 Landing Page Improvements

The landing page was further refined to present WimabEvent as a professional product.

Changes included:

- Added a professional developer/profile section.
- Added the developer image.
- Improved the public contact section.
- Added a clickable developer email address.
- Removed the personal phone number from the public contact section.
- Removed the location item from the contact section.
- Added a Wimab Event Hub description.
- Added a Get Started contact/action item.
- Added styling for the clickable email address.
- Continued improving the landing page visual presentation.

### 2.12 Events Page Visual Integration

The Events page visual design was refined to align more closely with the dashboard design system.

The page now uses the shared:

- Navy colour system.
- Gold accent system.
- Light application background.
- Border styling.
- Card radius.
- Card shadows.
- Hover animations.
- Button animations.
- Event card header styling.

The Events page remains connected to real backend event data.

### 2.13 Build Verification

The application successfully builds with:

`dotnet build`

The build currently succeeds with the existing SQLitePCLRaw.lib.e_sqlite3 vulnerability warning.

The warning does not currently prevent the application from building or running and is deferred for a later dependency/security-hardening stage.

---

## 3. Important Architecture Decisions

### 3.1 Server-Side Identity Is the Authentication Authority

The application now uses ASP.NET Core Identity as the authoritative authentication mechanism.

The server-side Identity session and authentication cookie determine whether the user is authenticated.

Client-controlled localStorage values such as `wimab_userid` are no longer treated as the authoritative source of authentication for the completed dashboard flow.

### 3.2 User Ownership Is Determined Server-Side

Authenticated user ownership is determined using the Identity user ID on the server.

The client is not trusted to specify which Identity user owns a newly created event.

This establishes the foundation for protecting other user-specific application resources.

### 3.3 Dashboard Data Is Database-Driven

Dashboard statistics and recent activity are retrieved from backend database queries rather than hardcoded presentation data.

This establishes the foundation for future real-time and user-specific application functionality.

---

## 4. Final Milestone Testing

The following functionality was verified during Milestone 2:

- [x] User registration
- [x] Valid login
- [x] Invalid login
- [x] Identity authentication session
- [x] Authentication cookie
- [x] Logout
- [x] Authenticated user lookup
- [x] Protected dashboard access
- [x] Event creation
- [x] User-specific event listing
- [x] User-specific event retrieval
- [x] User-specific event deletion
- [x] Server-side event ownership
- [x] Database-driven dashboard statistics
- [x] Database-driven recent events
- [x] Database-driven recent invitations
- [x] Removal of mock dashboard data
- [x] Dashboard authentication integration
- [x] Events page visual integration
- [x] Successful application build
- [x] Changes committed and pushed to GitHub

---

## 5. Development Journal

### 31 August 2026

Authentication integration was continued using ASP.NET Core Identity.

The login endpoint was changed from CheckPasswordSignInAsync to PasswordSignInAsync so that successful login establishes an authenticated Identity session.

A real test account was registered and successfully authenticated.

The authentication cookie was observed during testing, confirming that the Identity session was being established.

Event creation was then tested through the authenticated application. A test event was successfully created and displayed on the Events page.

The landing page was also refined with a professional developer section, developer image and improved contact information.

### 1 September 2026

Frontend testing revealed that the dashboard still contained hardcoded presentation data while the Events page was displaying real database data.

The dashboard was then connected to a protected backend dashboard API.

Dashboard statistics were converted to real database-driven values.

Recent events and recent invitations were connected to backend data and rendered dynamically.

Hardcoded dashboard events and invitation activity were removed.

Authentication checks were integrated with the server-side Identity session.

Event ownership was secured so that the authenticated user is used as the authoritative owner of events.

The Events page was visually refined to align with the dashboard's professional design system.

The complete authentication, event ownership and dashboard integration flow was tested successfully.

Milestone 2 is now complete.

---

## 6. Milestone Completion Criteria

All Milestone 2 completion criteria have been satisfied:

- [x] Frontend login uses the real ASP.NET Core Identity authentication flow.
- [x] Registration and login are integrated with the authentication API.
- [x] Authenticated pages rely on the server-side authentication session.
- [x] Logout correctly ends the authenticated session.
- [x] Dashboard statistics come from the database.
- [x] Dashboard events belong to the authenticated user.
- [x] Mock dashboard data has been removed.
- [x] Guest, invitation and wishlist counts are retrieved through the dashboard backend.
- [x] User-specific event access has been secured.
- [x] The authentication and dashboard flow has been tested.
- [x] Changes have been committed and pushed to GitHub.

---

## 7. Current Checkpoint

**Milestone 1:** COMPLETE  
Gift Registry & Catalogue functionality completed, tested, committed and pushed.

**Milestone 2:** COMPLETE  
Authentication & Frontend Integration completed, tested, committed and pushed.

**Next milestone:** Milestone 3 — Invitations & RSVP

**Next development focus:** Secure invitation creation, invitation links, public guest RSVP, RSVP deadlines, plus-one handling, dietary requirements and the foundation for QR-based event check-in.

---

## 8. Next Development Direction

The next milestone will introduce the invitation and RSVP workflow.

The planned foundation includes:

- Host-controlled invitations.
- Secure invitation tokens/links.
- Guest invitation management.
- Public RSVP without requiring a guest account.
- Accept/decline responses.
- Plus-one handling.
- Dietary requirement collection.
- RSVP deadline enforcement.
- Invitation status tracking.
- Preparation for QR-based event tickets.
- Preparation for event check-in.

Milestone 3 will be documented separately before implementation begins.
